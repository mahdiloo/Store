using Store_Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Application.Interface.Context;
using Store_Application.Services.Common.Queries.GetSlider;

namespace Store_Application.Services.Common.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        ResultDto<List<HomePageImagesDto>> Execute();
        ResultDto<HomePageImagesDto> ExecuteDetails(long Id);
    }
   
}
