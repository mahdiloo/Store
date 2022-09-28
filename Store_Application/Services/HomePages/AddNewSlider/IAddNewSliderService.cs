using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.HomePages.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file,string? link);
    }

}
