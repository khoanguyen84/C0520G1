using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Module
{
    public  class ModuleView : ResView
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
    }
}
