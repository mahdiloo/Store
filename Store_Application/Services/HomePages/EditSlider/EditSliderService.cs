using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store_Application.Interface.Context;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Common.Dto;

namespace Store_Application.Services.HomePages.EditSlider
{
    public class EditSliderService : IEditSliderService
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EditSliderService(IDataBaseContext dataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _webHostEnvironment = WebHostEnvironment;
        }
        public ResultDto Exucte(IFormFile file, string? link, long Id)
        {
            var Slider = _dataBaseContext.Sliders.FirstOrDefault(p => p.Id == Id);
            if (Slider == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "رکورد یافت نشد.",
                };
            }




            //حذف تصویر قبلی          
            var oldimagepath = Path.Combine(_webHostEnvironment.WebRootPath, Slider.Src.TrimStart('\\'));
            if (System.IO.File.Exists(oldimagepath))
            {
                System.IO.File.Delete(oldimagepath);
            }

            var resultupload = UploadFile(file);

            Slider.Link = link;
            Slider.Src = resultupload;

            _dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت ویرایش شد",
            };

        }
        private string UploadFile(IFormFile? file)
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
