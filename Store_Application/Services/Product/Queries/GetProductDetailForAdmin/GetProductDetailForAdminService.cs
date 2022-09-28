using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Common.Dto;
using Store_Domain.Entities.Products;

namespace Store_Application.Services.Product.Queries.GetProductDetailForAdmin
{
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetProductDetailForAdminService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
         
        public ResultDto<ProductDetailForAdminDto> Execute(long Id)
        {
            var Products = _dataBaseContext.Products.Include(p => p.Category).ThenInclude(p => p.ParentCategory)
                  .Include(p => p.ProductFeatures).Include(p => p.ProductImages).Where(p => p.Id == Id)
                  .FirstOrDefault();
            return new ResultDto<ProductDetailForAdminDto>
            {
                Data = new ProductDetailForAdminDto
                {
                    Brand = Products.Brand,
                     Category = GetCategory(Products.Category),
                    Description = Products.Description,
                    Displayed = Products.Displayed,
                    Id = Products.Id,
                    Inventory = Products.Inventory,
                    Name = Products.Name,
                    Price = Products.Price,
                    Features = Products.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }
                    ).ToList(),
                    Images = Products.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src
                    }).ToList()
                },
                IsSuccess = true,
                Message = "",
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.Name}-" : "";
            return result += category.Name;
        }
    }
}
