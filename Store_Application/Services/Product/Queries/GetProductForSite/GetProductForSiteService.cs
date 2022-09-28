using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Common;
using Store_Common.Dto;

namespace Store_Application.Services.Product.Queries.GetProductForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetProductForSiteService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto<ResultProductForSiteDto> Execute(Ordering ordering,string Searchkey,int Page,int Pagesize,  long? CatId)
        {
            int TotalRow = 0;
            //var Products = _dataBaseContext.Products.Include(p => p.ProductImages).ToPaged(Page, 5, out TotalRow).ToList();
            var ProductsQurey = _dataBaseContext.Products.Include(p => p.ProductImages).AsQueryable();
            if(CatId!=null)
            {
                ProductsQurey = ProductsQurey.Where(p => p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(Searchkey))
            {
                ProductsQurey = ProductsQurey.Where(p => p.Name.Contains(Searchkey) || p.Brand.Contains(Searchkey)).AsQueryable();
            }

            switch (ordering)
            {
                case Ordering.NotOrder:
                    ProductsQurey = ProductsQurey.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    ProductsQurey = ProductsQurey.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    //ProductsQurey = ProductsQurey.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.theNewest:
                    ProductsQurey = ProductsQurey.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    ProductsQurey = ProductsQurey.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    ProductsQurey = ProductsQurey.OrderByDescending(p => p.Price).AsQueryable();
                    break;
            }

            var Products = ProductsQurey.ToPaged(Page,Pagesize,out TotalRow).ToList();

            Random rd = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = TotalRow,
                    Products = Products.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src
                    ,
                        Star = rd.Next(1, 5),
                        Price = p.Price
                    }
                        ).ToList(),

                },
                IsSuccess = true,
            };
        }
    }
}
