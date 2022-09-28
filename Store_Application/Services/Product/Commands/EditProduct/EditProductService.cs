using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store_Application.Interface.Context;
using Store_Common.Dto;
using Store_Domain.Entities.Products;

namespace Store_Application.Services.Product.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EditProductService(IDataBaseContext dataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = WebHostEnvironment;
        }
        public ResultDto Exucte(RequestEditProductDto request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام محصول را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.Brand))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = " برند را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.Description))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "  توضیحات را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.Price.ToString()))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "قیمت را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.Inventory.ToString()))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "تعداد را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.CategoryId.ToString()))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "دسته بندی را وارد نمایید",
                };
            }

            if (request.Images.Count==0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "تصویر را وارد نمایید",
                };
            }

            if (request.Features == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "ویژگی را وارد نمایید",
                };
            }
            var product = _dataBaseContext.Products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "رکورد یافت نشد.",
                };
            }

            product.Name = request.Name;
            product.Brand = request.Brand;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Inventory = request.Inventory;
            product.CategoryId = request.CategoryId;
            product.Displayed = request.Displayed;

            //حذف تصویر قبلی
            var imgs = _dataBaseContext.ProductImages.Where(p => p.ProductId == request.Id).ToList();
            if (imgs != null)
            {
                for (int i = 0; i < imgs.Count; i++)
                {
                    var oldimagepath = Path.Combine(_webHostEnvironment.WebRootPath, imgs[i].Src.TrimStart('\\'));
                    if (System.IO.File.Exists(oldimagepath))
                    {
                        System.IO.File.Delete(oldimagepath);
                    }

                    _dataBaseContext.ProductImages.Remove(imgs[i]);
                }
            }

            List<ProductImages> productImages = new List<ProductImages>();
            foreach (var item in request.Images)
            {
                var uploadedResult = UploadFile(item);
                productImages.Add(new ProductImages
                {
                    Product = product,
                    Src = uploadedResult,
                });
            }
            _dataBaseContext.ProductImages.AddRange(productImages);




            //حذف ویژگی های قبلی
            var Features = _dataBaseContext.ProductFeatures.Where(p => p.ProductId == request.Id).ToList();
            if (Features != null)
            {
                for (int i = 0; i < Features.Count; i++)
                {
                    _dataBaseContext.ProductFeatures.Remove(Features[i]);
                }
            }

            List<ProductFeatures> productFeatures = new List<ProductFeatures>();
            foreach (var item in request.Features)
            {
                productFeatures.Add(new ProductFeatures
                {
                    DisplayName = item.DisplayName,
                    Value = item.Value,
                    Product = product,
                });
            }
            _dataBaseContext.ProductFeatures.AddRange(productFeatures);

            _dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ویرایش شد",
            };

        }
        private string UploadFile(IFormFile? file)
        {

            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return "";

                }
                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return folder + fileName;

            }
            return "";
        }
    }
}
