using System;
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
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
