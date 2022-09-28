using Microsoft.AspNetCore.Http;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Application.Services.Product.Commands.EditProduct;
using Store_Common.Dto;
using Store_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.HomePages.EditSlider
{
    public interface IEditSliderService
    {
        ResultDto Exucte(IFormFile file, string? link, long Id);
    }

}
