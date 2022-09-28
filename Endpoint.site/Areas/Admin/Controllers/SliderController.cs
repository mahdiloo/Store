
using Dto.Response.Payment;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Application.Services.HomePages.AddNewSlider;
using Store_Application.Services.HomePages.EditSlider;
using Store_Application.Services.HomePages.RemoveSlider;
using Store_Application.Services.Product.Commands.EditCategory;
using Store_Application.Services.Product.Commands.EditProduct;
using Store_Application.Services.Product.FacadPattern;
using Store_Common;
using Store_Domain.Entities.Products;
using ZarinPal.Strategy.Interface;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class SliderController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;
        private readonly IGetSliderService _getSliderService;
        private readonly IRemoveSliderService _removeSliderService;
        private readonly IEditSliderService _editSliderService;

        public SliderController(IAddNewSliderService addNewSliderService, IGetSliderService getSliderService,IRemoveSliderService removeSliderService,
            IEditSliderService editSliderService)
        {
            _addNewSliderService = addNewSliderService;
            _getSliderService = getSliderService;
            _removeSliderService = removeSliderService;
            _editSliderService = editSliderService;
        }
        public IActionResult Index()
        {
            HomePageViewModel HomePge = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
            };

            return View(HomePge);
            //return View(_getSliderService.Execute().Data);
        }

       
        [HttpPost]
        public IActionResult Delete(long Id)
        {
                return Json(_removeSliderService.Execute(Id));
        }

        //Get
        [HttpGet]
        public IActionResult Edit(long Id)
        {
            return View(_getSliderService.ExecuteDetails(Id).Data);
        }
        [HttpPost]
        public IActionResult Edit(IFormFile file, string? link, long Id)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                file = Request.Form.Files[i];
            }
            return Json(_editSliderService.Exucte( file, link,Id));
        }
        
        //Get
        [HttpGet]
        public IActionResult Create(long? parentId)
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(IFormFile file, string? link)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                file = Request.Form.Files[i];
            }
            return Json(_addNewSliderService.Execute(file, link));
        }
           
    }
}
