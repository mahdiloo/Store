
using Store_Domain.Entities.HomePages;
using Microsoft.EntityFrameworkCore;
using Store_Domain.Entities.Commons;
using Store_Domain.Entities.Products;
using Store_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Domain.Entities.Carts;
using Store_Domain.Entities.Finances;
using Store_Domain.Entities.Orders;

namespace Store_Application.Interface.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Productt> Products { get; set; }
        DbSet<ProductImages> ProductImages { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<HomePageImages> HomePageImages { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<RequestPay> RequestPays { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }

        int SaveChanges(bool acceptAllchangesonsuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllchangesonsuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
