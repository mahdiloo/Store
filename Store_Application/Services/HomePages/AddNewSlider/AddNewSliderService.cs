using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store_Application.Interface.Context;
using Store_Application.Services.Product.Commands.AddNewProduct;
using Store_Common.Dto;
using Store_Domain.Entities.HomePages;

namespace Store_Application.Services.HomePages.AddNewSlider
{
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AddNewSliderService(IDataBaseContext dataBaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public ResultDto Execute(IFormFile file, string? link)
        {
            if (file==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "تصویر را وارد نمایید",
                };
            }
            var resultupload = UploadFile(file);

            Slider slider = new Slider
            {
                Link = link,
                Src = resultupload.FileNameAddress,
            };
            _dataBaseContext.Sliders.Add(slider);
            _dataBaseContext.SaveChanges();

            return new ResultDto
            { IsSuccess = true, 
            Message="اسلایدر با موفقیت ثبت شد."};
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

}
