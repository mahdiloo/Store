using Store_Application.Services.Product.Commands.RemoveCategory;
using Store_Application.Services.Product.Commands.AddNewCategory;
using Store_Application.Services.Product.Commands.AddNewProduct;
using Store_Application.Services.Product.Queries.GetProductDetailForAdmin;
using Store_Application.Services.Product.Queries.GetProductDetailForSite;
using Store_Application.Services.Product.Queries.GetProductForAdmin;
using Store_Application.Services.Product.Queries.GetProductForSite;
using Store_Application.Services.Product.Queries.GetAllCategories;
using Store_Application.Services.Product.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Application.Services.Product.FacadPattern;
using Store_Application.Services.Product.Commands.EditCategory;
using Store_Application.Services.Product.Commands.EditProduct;
using Store_Application.Services.Product.Commands.RemoveProduct;

namespace Store_Application.Interface.FacadPattern
{
    public interface IProductFacad
    {
        IGetCategoriesService IGetCategoriesService { get; }
        IGetAllCategoriesService IGetAllCategoriesService { get; }

        //دسته بندی ها
        AddNewCategoryService AddNewCategoryService { get; }
        IAddNewCategoryService IAddNewCategoryService { get; }
        //محصولات
        AddNewProductService AddNewProductService { get; }
        IAddNewProductService IAddNewProductService { get; }

        //نمایش لیست محصولات در ادمین
        IGetProductForAdminService IGetProductForAdminService { get; }
        //نمایش جزئیات محصولات در ادمین
        IGetProductDetailForAdminService IGetProductDetailForAdminService { get; }
        //نمایش لیست محصولات در سایت
        IGetProductForSiteService IGetProductForSiteService { get; }
        //نمایش جزئیات محصولات در سایت
        IGetProductDetailForSiteService IGetProductDetailForSiteService { get; }

        //حذف دسته بندی ها
        IRemoveCategoryService IRemoveCategoryService { get; }
        RemoveCategoryService RemoveCategoryService { get; }
        IEditCategoryService IEditCategoryService { get; }
        EditCategoryService EditCategoryService { get; }

        IEditProductService IEditProductService { get; }
        EditProductService EditProductService { get; }
        IRemoveProductService IRemoveProductService { get; }
        RemoveProductService RemoveProductService { get; }
    }
}
