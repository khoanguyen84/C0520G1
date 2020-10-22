using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain
{
    public class ModuleViewModel
    {
        public int ModuleId { get; set; }
        public string ModuleName{ get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
