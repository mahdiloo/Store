
using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Application.Services.Product.FacadPattern;
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

namespace Store_Application.Services.Product.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public AddNewCategoryService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public Category GetParent(long? ParentId)
        {
            return _dataBaseContext.Categories.Find(ParentId);
        }
        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }

            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId)
            };
            _dataBaseContext.Categories.Add(category);
            _dataBaseContext.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
        }
        //public ResultDto Add(Category entity)
        //{

        //    _dataBaseContext.Categories.Add(entity);
        //    _dataBaseContext.SaveChanges();
        //    return new ResultDto()
        //    {
        //        IsSuccess = true,
        //        Message = "دسته بندی با موفقیت اضافه شد",
        //    };
        //}

        //public ResultDto<IEnumerable<Category>> GetAll()
        //{
        //    IEnumerable<Category> query = _dataBaseContext.Categories;

        //    return new ResultDto<IEnumerable<Category>>
        //    {
        //        Data = _dataBaseContext.Categories,
        //        IsSuccess = false,
        //        Message = "",
        //    };
        //    //return query;
        //}

        //public Category GetFirstOrDefault(Expression<Func<Category, bool>> Filter)
        //{
        //    IQueryable<Category> query = _dataBaseContext.Categories;
        //    query = query.Where(Filter);
        //    return query.FirstOrDefault();
        //}

        //public void Remove(Category entity)
        //{
        //    _dataBaseContext.Categories.Remove(entity);
        //    _dataBaseContext.SaveChanges();
        //}

        //public void RemoveRange(IEnumerable<Category> entity)
        //{
        //    _dataBaseContext.Categories.RemoveRange(entity);
        //    _dataBaseContext.SaveChanges();
        //}

        //public void Update(Category entity)
        //{
        //    Category category = new Category()
        //    {
        //        Name = entity.Name,
        //        ParentCategory = GetParent(entity.Id)
        //    };
        //    _dataBaseContext.Categories.Update(category);
        //    _dataBaseContext.SaveChanges();
        //}
    }
}
