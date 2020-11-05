using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Module
{
    public class ModuleView
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }     
        
        public string StatusName { get; set; }
    }
}
