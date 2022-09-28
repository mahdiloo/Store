using Store_Application.Interface.Context;
using Store_Common.Dto;

namespace Store_Application.Services.Product.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public RemoveProductService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(long Id)
        {
            var obj = _dataBaseContext.Products.FirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "حذف ناموفق بود.",
                };

            }

            //_dataBaseContext.Products.Remove(obj);
            obj.IsRemoved = true;
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = ".محصول حذف شد",
            };
        }
    }
}
