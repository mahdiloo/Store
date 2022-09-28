
using System.Linq.Expressions;
using Store_Application.Interface.Context;
using Store_Common.Dto;
using Store_Domain.Entities.Products;

namespace Store_Application.Services.Product.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }
}
