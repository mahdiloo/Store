
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Product.Queries.GetProductForSite;
using Store_Common;
using Store_Domain.Entities.Products;
using System.Drawing.Printing;

namespace Endpoint.site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(Ordering ordering,string SearchKey, int Page=1,int Pagesize=20,long? CatId=null)
        {
            return View(_productFacad.IGetProductForSiteService.Execute( ordering,SearchKey, Page, Pagesize, CatId).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_productFacad.IGetProductDetailForSiteService.Execute(Id).Data);
        }

    }
}
