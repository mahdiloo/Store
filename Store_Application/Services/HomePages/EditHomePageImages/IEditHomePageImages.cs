using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store_Application.Interface.Context;
using Store_Application.Services.Common.Queries.GetHomePageImages;
using Store_Common.Dto;
using Store_Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.HomePages.EditHomePageImages
{
    public interface IEditHomePageImages
    {
        ResultDto Exucte(RequestHomePageImagesDto request);
    }
    public class EditHomePageImages : IEditHomePageImages
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditHomePageImages(IDataBaseContext dataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = WebHostEnvironment;
        }

        ResultDto IEditHomePageImages.Exucte(RequestHomePageImagesDto request)
        {
            var HomePagesImage = _dataBaseContext.HomePageImages.FirstOrDefault(p => p.Id == request.Id);
            if (HomePagesImage == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "رکورد یافت نشد.",
                };
            }


            //حذف تصویر قبلی          
            var oldimagepath = Path.Combine(_webHostEnvironment.WebRootPath, HomePagesImage.Src.TrimStart('\\'));
            if (System.IO.File.Exists(oldimagepath))
            {
                System.IO.File.Delete(oldimagepath);
            }

            var resultupload = UploadFile(request.file);

            HomePagesImage.link = request.Link;
            HomePagesImage.Src = resultupload;

            _dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "تصویر با موفقیت ویرایش شد",
            };

        }


        private string UploadFile(IFormFile? file)
        {

            if (file != null)
            {
                string folder = $@"images\HomePages\HomePagesImage\";
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
    public class RequestHomePageImagesDto
    {
        public long Id { get; set; }
        public IFormFile file { get; set; }
        public string? Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
