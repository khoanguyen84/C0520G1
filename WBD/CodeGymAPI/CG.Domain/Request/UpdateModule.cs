﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request
{
     public class UpdateModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
    }
}
