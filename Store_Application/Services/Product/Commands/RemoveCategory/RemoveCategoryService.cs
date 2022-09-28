
using Microsoft.EntityFrameworkCore;
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

namespace Store_Application.Services.Product.Commands.RemoveCategory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public RemoveCategoryService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(long Id)
        {

           
            var obj = _dataBaseContext.Categories.FirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "حذف ناموفق بود.",
                };

            }
            var subobj = _dataBaseContext.Categories.FirstOrDefault(u => u.ParentCategoryId == Id);
            if (subobj !=null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر گرامی، دسته انتخاب شده زیر دسته دارد و امکان حذف نیست.",
                };
            }

            _dataBaseContext.Categories.Remove(obj);                    
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = ".دسته بندی حذف شد",
            };
        }
       
    }
}
