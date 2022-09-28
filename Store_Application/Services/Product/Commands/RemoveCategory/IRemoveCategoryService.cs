using Store_Common.Dto;
using Store_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Product.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(long Id);
    }
}
