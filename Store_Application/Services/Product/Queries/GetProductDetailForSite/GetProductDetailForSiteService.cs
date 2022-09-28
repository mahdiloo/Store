using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Common.Dto;
using Store_Domain.Entities.Products;

namespace Store_Application.Services.Product.Queries.GetProductDetailForSite
{
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetProductDetailForSiteService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var Products = _dataBaseContext.Products.Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory).Include(p => p.ProductFeatures).Include(p => p.ProductImages)
                .Where(p => p.Id == Id).FirstOrDefault();
            if (Products == null)
            {
                throw new Exception("Product Not Found.....");
            }

            Products.ViewCount++;
            _dataBaseContext.SaveChanges();
            return new ResultDto<ProductDetailForSiteDto>
            {
                Data = new ProductDetailForSiteDto
                {
                    Id = Products.Id,
                    Title = Products.Name,
                    Brand = Products.Brand,
                    Category = GetCategory(Products.Category),
                    Description = Products.Description,
                    Price = Products.Price,
                    Images = Products.ProductImages.Select(p => p.Src).ToList(),
                    Features = Products.ProductFeatures.Select(p => new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList()

                },
                IsSuccess=true
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.Name}-" : "";
            return result += category.Name;
        }
    }
}
