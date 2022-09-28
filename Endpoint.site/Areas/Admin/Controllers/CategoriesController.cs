
using Microsoft.AspNetCore.Mvc;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Product.Commands.EditCategory;
using Store_Common;
using Store_Domain.Entities.Products;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.IGetCategoriesService.Execute(parentId).Data);
        }
        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_productFacad.IRemoveCategoryService.Execute(Id));
        }
        [HttpPost]
        public IActionResult Edit(RequestEditCategoryDto request)
        {
            return Json(_productFacad.IEditCategoryService.Execute(request));
        }
        //public IActionResult Index()
        //{

        //    IEnumerable<Category> CategoriList = _productFacad.CategoryService.GetAll().Data;
        //    return View(CategoriList);
        //}
        //Get
        [HttpGet]
        public IActionResult Create(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(long? ParentId, string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
        //[HttpPost]
        //public IActionResult Create(Category obj, long? parentId)
        //{
        //    Category category = new Category()
        //    {
        //        Name = obj.Name,
        //        ParentCategoryId = parentId,
        //        ParentCategory = _productFacad.CategoryService.GetParent(parentId)
        //    };
        //   var res= _productFacad.CategoryService.Add(category);
        //    TempData["success"] = "دسته جدید با موفقیت ایجاد شد.";
        //    //return RedirectToAction("Index");

        //    return Json(res);
        //}       
    }
}
