
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Store_Application.Interface.Context;
using Store_Application.Services.Users.Queries.GetUsers;
using Store_Common.Dto;
using Store_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store_Application.Services.Product.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddNewProductService(IDataBaseContext dataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = WebHostEnvironment;
        }
        public Productt GetParent(long? ParentId)
        {
            return _dataBaseContext.Products.Find(ParentId);
        }
        public ResultDto Execute(RequestAddNewProductDto request)
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

            if (request.Images.Count == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "تصویر را وارد نمایید",
                };
            }

            if (request.Features==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "ویژگی را وارد نمایید",
                };
            }

            try
            {

                var category = _dataBaseContext.Categories.Find(request.CategoryId);

                Productt product = new Productt()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _dataBaseContext.Products.Add(product);

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
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }
        //public ResultDto add(Productt entity, List<IFormFile> file, List<ProductFeatures> Features)
        //{
        //    try
        //    {
        //        _dataBaseContext.Products.Add(entity);

        //        List<ProductImages> productImages = new List<ProductImages>();
        //        foreach (var item in file)
        //        {
        //            var uploadedResult = UploadFile(item);
        //            productImages.Add(new ProductImages
        //            {
        //                Product = entity,
        //                Src = uploadedResult,
        //            });
        //        }

        //        _dataBaseContext.ProductImages.AddRange(productImages);


        //        List<ProductFeatures> productFeatures = new List<ProductFeatures>();
        //        foreach (var item in Features)
        //        {
        //            productFeatures.Add(new ProductFeatures
        //            {
        //                DisplayName = item.DisplayName,
        //                Value = item.Value,
        //                Product = entity,
        //            });
        //        }
        //        _dataBaseContext.ProductFeatures.AddRange(productFeatures);

        //        _dataBaseContext.SaveChanges();

        //        return new ResultDto
        //        {
        //            IsSuccess = true,
        //            Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        return new ResultDto
        //        {
        //            IsSuccess = false,
        //            Message = "خطا رخ داد ",
        //        };
        //    }
        //}

        //public IEnumerable<Productt> GetAll()
        //{
        //    IEnumerable<Productt> query = _dataBaseContext.Products;

        //    return query;
        //}

        //public Productt GetFirstOrDefault(Expression<Func<Productt, bool>> Filter)
        //{
        //    IQueryable<Productt> query = _dataBaseContext.Products;
        //    query = query.Where(Filter);
        //    return query.FirstOrDefault();
        //}

        //public void Remove(Productt entity)
        //{
        //    _dataBaseContext.Products.Remove(entity);
        //    _dataBaseContext.SaveChanges();
        //}

        //public void RemoveRange(IEnumerable<Productt> entity)
        //{
        //    _dataBaseContext.Products.RemoveRange(entity);
        //    _dataBaseContext.SaveChanges();
        //}

        //public void Update(Productt entity)
        //{
        //    _dataBaseContext.Products.Update(entity);
        //    _dataBaseContext.SaveChanges();
        //}
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
