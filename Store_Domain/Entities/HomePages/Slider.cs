﻿using Store_Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Domain.Entities.HomePages
{
    public class Slider:BaseEntity
    {
        public string? Link { get; set; }
        public string Src { get; set; }
    }
}
