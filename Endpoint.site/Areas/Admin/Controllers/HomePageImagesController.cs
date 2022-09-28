using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store_Domain.Entities.HomePages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_Application.Services.HomePages.AddHomePageImages;
using Store_Common;
using EndPoint.Site.Models.ViewModels.HomePages;
using Store_Application.Services.Product.Queries.GetProductForSite;
using Store_Application.Services.Common.Queries.GetHomePageImages;
using Store_Application.Services.HomePages.RemoveHomePageImages;
using Store_Common.Dto;
using Dto.Response.Payment;
using Store_Application.Services.HomePages.EditHomePageImages;
using Store_Application.Services.Users.Commands.RgegisterUser;
using Store_Domain.Entities.Users;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class HomePageImagesController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;
        private readonly IGetHomePageImagesService _getHomePageImagesService;
        private readonly IRemoveHomePageImagesService _removeHomePageImagesService;
        private readonly IEditHomePageImages _editHomePageImages;

        public HomePageImagesController(IAddHomePageImagesService addHomePageImagesService, IGetHomePageImagesService getHomePageImagesService
            , IRemoveHomePageImagesService removeHomePageImagesService, IEditHomePageImages editHomePageImages)
        {
            _addHomePageImagesService = addHomePageImagesService;
            _getHomePageImagesService = getHomePageImagesService;
            _removeHomePageImagesService = removeHomePageImagesService;
            _editHomePageImages = editHomePageImages;
        }
        public IActionResult Index(requestAddHomePageImagesDto request)
        {
            HomePageViewModel HomePge = new HomePageViewModel()
            {
                PageImages = _getHomePageImagesService.Execute().Data,
            };

            return View(HomePge);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_removeHomePageImagesService.Execute(Id));
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            ResultDto resultDto = _addHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                file = (IFormFile)Request.Form.Files,
                ImageLocation = imageLocation,
                Link = link,
            });
            return Json(resultDto);
            // _addHomePageImagesService.Execute(new requestAddHomePageImagesDto
            //{
            //    file = file,
            //    ImageLocation = imageLocation,
            //    Link = link,
            //});
            //return View();
        }

        //Get
        [HttpGet]
        public IActionResult Edit(long Id)
        {
            return View(_getHomePageImagesService.ExecuteDetails(Id).Data);
        }
        [HttpPost]
        public IActionResult Edit(IFormFile file, string? link, long Id, ImageLocation ImageLocation)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                file = Request.Form.Files[i];
            }
            var request = _editHomePageImages.Exucte(new RequestHomePageImagesDto
            {
                Id = Id,
                Link = link,
                file = file,
                ImageLocation = ImageLocation,
            });

            return Json(request);
        }

    }
}
