using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Packaging.Signing;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Common.Queries.GetCategory;
using Store_Application.Services.Common.Queries.GetHomePageImages;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Application.Services.Product.Queries.GetProductForSite;
using Store_Domain.Entities.HomePages;
using Store_Domain.Entities.Orders;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductFacad _productFacad;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _homePageImagesService;
        

        public HomeController(ILogger<HomeController> logger,IProductFacad productFacad,IGetSliderService getSliderService
            , IGetHomePageImagesService homePageImagesService)
        {
            _logger = logger;
            _productFacad = productFacad;
            _getSliderService = getSliderService;
            _homePageImagesService= homePageImagesService;
        }
        public IActionResult Index()
        {
            HomePageViewModel HomePge = new HomePageViewModel()
            {

                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImagesService.Execute().Data,
                Camera = _productFacad.IGetProductForSiteService.Execute(Ordering.theNewest
                , null, 1, 6, 19).Data.Products,
                Mobile = _productFacad.IGetProductForSiteService.Execute(Ordering.theNewest
                , null, 1, 6, 14).Data.Products,
                Laptop = _productFacad.IGetProductForSiteService.Execute(Ordering.theNewest
                , null, 1, 6, 8).Data.Products,
              
        };

            return View(HomePge);
        }
        //public IActionResult Index(Ordering ordering,string Searchkey,int Page = 1,int Pagesize=20,long? CatId=null)
        //{
        //    return View(_productFacad.IGetProductForSiteService.Execute( ordering, Searchkey,Page, Pagesize, CatId).Data);
        //}

        public IActionResult Detail(long Id)
        {
            return View(_productFacad.IGetProductDetailForSiteService.Execute(Id).Data);
        }


    }
}
