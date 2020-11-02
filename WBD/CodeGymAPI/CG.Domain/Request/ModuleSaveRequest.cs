using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request
{
   public class ModuleSaveRequest
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
     
        public int CreateBy { get; set; }
      
        public int ModifiedBy { get; set; }
    }
}
