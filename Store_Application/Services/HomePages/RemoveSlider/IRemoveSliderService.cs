using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.HomePages.RemoveSlider
{
    public interface IRemoveSliderService
    {
        ResultDto Execute(long Id);
    }
}
