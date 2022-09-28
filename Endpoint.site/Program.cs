
using Store_Application.Services.HomePages.AddHomePageImages;
using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Common.Queries.GetCategory;
using Store_Application.Services.Common.Queries.GetHomePageImages;
using Store_Application.Services.Common.Queries.GetMenuItem;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Application.Services.HomePages.AddNewSlider;
using Store_Application.Services.HomePages.EditSlider;
using Store_Application.Services.HomePages.RemoveSlider;
using Store_Application.Services.Product.FacadPattern;
using Store_Application.Services.Users.Queries.GetUsers;
using Store_Persistence.Context;
using Store_Application.Services.HomePages.RemoveHomePageImages;
using Store_Application.Services.Carts;
using Store_Application.Services.Users.Queries.GetRoles;
using Store_Application.Services.Users.Commands.RgegisterUser;
using Store_Application.Services.Users.Commands.RemoveUser;
using Store_Application.Services.Users.Commands.UserLogin;
using Store_Application.Services.Users.Commands.UserSatusChange;
using Store_Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Store_Common.Roles;
using Store_Application.Services.Fainances.Commands.AddRequestPay;
using Store_Application.Services.Fainances.Queries.GetRequestPayService;
using Store_Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Store_Application.Services.Orders.Commands.AddNewOrder;
using Store_Application.Services.Orders.Queries.GetOrdersForAdmin;
using Store_Application.Services.Orders.Queries.GetUserOrders;
using Store_Application.Services.Users.Queries.GetDetailsUser;
using Store_Application.Services.Fainances.Queries.GetPayDetailService;
using Store_Application.Services.HomePages.EditHomePageImages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(Options => Options.UseSqlServer
(builder.Configuration.GetConnectionString("DefultConnection")));



builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();

builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IRemoveSliderService, RemoveSliderService>();
builder.Services.AddScoped<IEditSliderService, EditSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();
builder.Services.AddScoped<IRemoveHomePageImagesService, RemoveHomePageImagesService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();
builder.Services.AddScoped<IGetDetailsUserService, GetDetailsUserService>();
builder.Services.AddScoped<IGetPayDetailService, GetPayDetailService>();
builder.Services.AddScoped<IEditHomePageImages, EditHomePageImages>();




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString($"/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString($"/Authentication/Signin");
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Authentication/Signin";
    options.LogoutPath = $"/Authentication/Signup";
    options.AccessDeniedPath = $"/Authentication/Signin";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


//app.MapControllerRoute(
//  name: "areas",
//  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
       name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});

app.Run();
