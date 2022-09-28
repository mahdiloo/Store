

using Store_Application.Services.Product.Queries.GetAllCategories;
using Store_Application.Services.Product.Queries.GetCategories;
using Microsoft.AspNetCore.Hosting;
using Store_Application.Interface.Context;
using Store_Application.Interface.FacadPattern;
using Store_Application.Services.Product.Commands.AddNewCategory;
using Store_Application.Services.Product.Commands.AddNewProduct;
using Store_Application.Services.Product.Queries.GetProductDetailForAdmin;
using Store_Application.Services.Product.Queries.GetProductDetailForSite;
using Store_Application.Services.Product.Queries.GetProductForAdmin;
using Store_Application.Services.Product.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Application.Services.Product.Commands.RemoveCategory;
using Store_Application.Services.Product.Commands.EditCategory;
using Store_Application.Services.Product.Commands.EditProduct;
using Store_Application.Services.Product.Commands.RemoveProduct;

namespace Store_Application.Services.Product.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext dataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = WebHostEnvironment;
        }

        private IGetCategoriesService _IGetCategoriesService;
        public IGetCategoriesService IGetCategoriesService
        {
            get
            {
                return _IGetCategoriesService = _IGetCategoriesService ?? new GetCategoriesService(_dataBaseContext);
            }
        }


        private IGetAllCategoriesService _IGetAllCategoriesService;
        public IGetAllCategoriesService IGetAllCategoriesService
        {
            get
            {
                return _IGetAllCategoriesService = _IGetAllCategoriesService ?? new GetAllCategoriesService(_dataBaseContext);
            }
        }



        private AddNewCategoryService _AddNewCategoryService;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _AddNewCategoryService = _AddNewCategoryService ?? new AddNewCategoryService(_dataBaseContext);
            }
        }


        private IAddNewCategoryService _IAddNewCategoryService;
        public IAddNewCategoryService IAddNewCategoryService
        {
            get
            {
                return _IAddNewCategoryService = _IAddNewCategoryService ?? new AddNewCategoryService(_dataBaseContext);
            }
        }


        private AddNewProductService _AddNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _AddNewProductService = _AddNewProductService ?? new AddNewProductService(_dataBaseContext, _webHostEnvironment);
            }
        }
        private IAddNewProductService _IAddNewProductService;
        public IAddNewProductService IAddNewProductService
        {
            get
            {
                return _IAddNewProductService = _IAddNewProductService ?? new AddNewProductService(_dataBaseContext, _webHostEnvironment);
            }
        }

        private IGetProductForAdminService _iGetProductForAdminService;
        public IGetProductForAdminService IGetProductForAdminService
        {
            get
            {
                return _iGetProductForAdminService = _iGetProductForAdminService ?? new GetProductForAdminService(_dataBaseContext);
            }
        }
        private IGetProductDetailForAdminService _iGetProductDetailForAdminService;
        public IGetProductDetailForAdminService IGetProductDetailForAdminService
        {
            get
            {
                return _iGetProductDetailForAdminService = _iGetProductDetailForAdminService ?? new GetProductDetailForAdminService(_dataBaseContext);
            }
        }

        private IGetProductForSiteService _iGetProductForSiteService;

        public IGetProductForSiteService IGetProductForSiteService
        {
            get
            {
                return _iGetProductForSiteService = _iGetProductForSiteService ?? new GetProductForSiteService(_dataBaseContext);
            }
        }
        private IGetProductDetailForSiteService _iGetProductDetailForSiteService;
        public IGetProductDetailForSiteService IGetProductDetailForSiteService
        {
            get
            {
                return _iGetProductDetailForSiteService = _iGetProductDetailForSiteService ?? new GetProductDetailForSiteService(_dataBaseContext);
            }
        }

        private IRemoveCategoryService _IRemoveCategoryService;
        public IRemoveCategoryService IRemoveCategoryService
        {
            get
            {
                return _IRemoveCategoryService = _IRemoveCategoryService ?? new RemoveCategoryService(_dataBaseContext);
            }
        }

        private RemoveCategoryService _RemoveCategoryService;
        public RemoveCategoryService RemoveCategoryService
        {
            get
            {
                return _RemoveCategoryService = _RemoveCategoryService ?? new RemoveCategoryService(_dataBaseContext);
            }
        }

        private EditCategoryService _EditCategoryServicee;
        public EditCategoryService EditCategoryService
        {
            get
            {
                return _EditCategoryServicee = _EditCategoryServicee ?? new EditCategoryService(_dataBaseContext);
            }
        }

        private IEditCategoryService _IEditCategoryService;
        public IEditCategoryService IEditCategoryService
        {
            get
            {
                return _IEditCategoryService = _IEditCategoryService ?? new EditCategoryService(_dataBaseContext);
            }
        }

        private IEditProductService _IEditProductService;
        public IEditProductService IEditProductService
        {
            get
            {
                return _IEditProductService = _IEditProductService ?? new EditProductService(_dataBaseContext, _webHostEnvironment);
            }
        }
        private EditProductService _EditProductService;
        public EditProductService EditProductService
        {
            get
            {
                return _EditProductService = _EditProductService ?? new EditProductService(_dataBaseContext, _webHostEnvironment);
            }
        }

        private IRemoveProductService _IRemoveProductService;
        public IRemoveProductService IRemoveProductService
        {
            get
            {
                return _IRemoveProductService = _IRemoveProductService ?? new RemoveProductService(_dataBaseContext);
            }
        }
        private RemoveProductService _RemoveProductService;
        public RemoveProductService RemoveProductService
        {
            get
            {
                return _RemoveProductService = _RemoveProductService ?? new RemoveProductService(_dataBaseContext);
            }
        }
    }
}
