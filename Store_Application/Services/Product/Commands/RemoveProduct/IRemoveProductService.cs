using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Product.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(long Id);
    }
}
