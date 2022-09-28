using Store_Application.Interface.Context;
using Store_Common.Dto;

namespace Store_Application.Services.Product.Commands.EditCategory
{
    public class EditCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public EditCategoryService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(RequestEditCategoryDto request)
        {

            var obj = _dataBaseContext.Categories.FirstOrDefault(u => u.Id == request.Id);
            if (obj == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "رکورد یافت نشد.",
                };

            }
            obj.Name = request.Name;
            //_dataBaseContext.Categories.Update(obj);
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = ".دسته بندی ویرایش شد",
            };
        }
    }
}
