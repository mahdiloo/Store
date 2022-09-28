using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Application.Services.Product.Queries.GetProductDetailForSite;
using Store_Common;
using Store_Common.Dto;
using Store_Domain.Entities.Products;
using static System.Net.Mime.MediaTypeNames;

namespace Store_Application.Services.Product.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _dataBaseContext = context;
        }
        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowcount = 0;
            var Products = _dataBaseContext.Products.Include(p => p.Category)
              .ThenInclude(p => p.ParentCategory).Include(p => p.ProductFeatures).Include(p => p.ProductImages).ToPaged(Page, PageSize, out rowcount)
              .Select
                (p => new ProductForAdminListDto
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Category = p.Category.ParentCategory != null ? $"{p.Category.Name}-":"" + p.Category.Name,
                    Description = p.Description,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                    Images=p.ProductImages.Select(i=>i.Src).ToList(),
                    Features=p.ProductFeatures.Select(f=> new ProductForAdminList_Features
                    {
                        DisplayName = f.DisplayName,
                        Value = f.Value
                    }).ToList(),
                }).ToList();
            return new ResultDto<ProductForAdminDto>
            {
                Data = new ProductForAdminDto
                {
                    Products = Products,
                    RowCount = rowcount,
                    PageSize = PageSize,
                    CurrentPage = Page
                },
                IsSuccess = true,
                Message = ""
            };



            //int rowcount = 0;
            //var Products = _dataBaseContext.Products.Include(p => p.Category).ToPaged(Page, PageSize, out rowcount).Select
            //    (p => new ProductForAdminListDto
            //    {
            //        Id = p.Id,
            //        Brand = p.Brand,
            //        Category = p.Category.Name,
            //        Description = p.Description,
            //        Displayed = p.Displayed,
            //        Inventory = p.Inventory,
            //        Name = p.Name,
            //        Price = p.Price,
            //    }).ToList();
            //return new ResultDto<ProductForAdminDto>
            //{
            //    Data = new ProductForAdminDto
            //    {
            //        Products = Products,
            //        RowCount = rowcount,
            //        PageSize = PageSize,
            //        CurrentPage = Page
            //    },
            //    IsSuccess = true,
            //    Message = ""
            //};
        }
    }
}
