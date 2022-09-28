using Store_Application.Services.Product.Commands.AddNewProduct;
using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Product.Commands.EditProduct
{
    public interface IEditProductService
    {
        ResultDto Exucte(RequestEditProductDto request);
    }
}
