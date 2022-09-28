
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Product.Commands.AddNewProduct;
using Store_Application.Services.Product.Commands.EditProduct;
using Store_Application.Services.Product.Queries.GetProductDetailForAdmin;
using Store_Common;
using Store_Domain.Entities.Products;
using Store_Persistence.Migrations;
using System.Drawing.Printing;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            return View(_productFacad.IGetProductForAdminService.Execute(Page,PageSize).Data);
        }
        public IActionResult Detail (long Id)
        {
            return View(_productFacad.IGetProductDetailForAdminService.Execute(Id).Data);
        }
      
        //Get
        [HttpGet]
        public IActionResult Create()
        {        
            ViewBag.Categories = new SelectList(_productFacad.IGetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;         
            return Json(_productFacad.IAddNewProductService.Execute(request));     
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            ViewBag.Categories = new SelectList(_productFacad.IGetAllCategoriesService.Execute().Data, "Id", "Name");
            return View(_productFacad.IGetProductDetailForAdminService.Execute(Id).Data);
        }
        [HttpPost]
        public IActionResult Edit(RequestEditProductDto request, List<EditProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacad.IEditProductService.Exucte(request));
        }
        //public IActionResult Create(Productt obj, List<IFormFile> filerequest, List<ProductFeatures> Features)
        //{
        //    List<IFormFile> images = new List<IFormFile>();
        //    for (int i = 0; i < Request.Form.Files.Count; i++)
        //    {
        //        var file = Request.Form.Files[i];
        //        images.Add(file);
        //    }
        //    filerequest = images;
        //    var res= _productFacad.IAddNewProductService.Execute(obj, filerequest, Features);
        //    TempData["success"] = "محصول جدید با موفقیت ایجاد شد.";

        //    return Json(res);
        //}
        //
        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_productFacad.IRemoveProductService.Execute(Id));
        }
    }
}
