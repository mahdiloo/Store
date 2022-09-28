﻿using Store_Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
