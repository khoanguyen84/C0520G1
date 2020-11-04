using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request.Module
{
    public class SaveModuleReq
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Status { get; set; }
        public int Duration { get; set; }
        public int @SavedBy { get; set; }
    }
}
