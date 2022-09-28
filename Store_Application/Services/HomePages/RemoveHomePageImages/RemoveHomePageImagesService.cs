using Store_Application.Interface.Context;
using Store_Common.Dto;

namespace Store_Application.Services.HomePages.RemoveHomePageImages
{
    public class RemoveHomePageImagesService : IRemoveHomePageImagesService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public RemoveHomePageImagesService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(long Id)
        {
            var obj = _dataBaseContext.HomePageImages.FirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "حذف ناموفق بود.",
                };

            }

            //_dataBaseContext.Sliders.Remove(obj);
            obj.IsRemoved = true;
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "تصویر حذف شد",
            };
        }
    }
}
