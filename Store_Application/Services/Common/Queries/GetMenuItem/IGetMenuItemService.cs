﻿using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
}
