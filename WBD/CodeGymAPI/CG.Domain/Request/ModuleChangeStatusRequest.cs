using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request
{
   public class ModuleChangeStatusRequest
    {
        public int ModuleId { get; set; }
        public int Status { get; set; }
        public int ModifiedBy { get; set; }
    }
}
