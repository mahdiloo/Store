using Microsoft.AspNetCore.Mvc;
using Store_Application.Services.Common.Queries.GetCategory;
using Store_Application.Services.Product.Queries.GetProductForSite;

namespace Endpoint.site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Search(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getCategoryService.Execute().Data);
        }
        //private readonly IGetProductForSiteService _getProductForSiteService;
        //public Search(IGetProductForSiteService getProductForSiteService)
        //{
        //    _getProductForSiteService = getProductForSiteService;
        //}


        //public IViewComponentResult Invoke()
        //{
        //    return View(viewName: "Search", _getProductForSiteService.Execute(0, SearchKey, 1, 20, null).Data);
        //}

    }
}
