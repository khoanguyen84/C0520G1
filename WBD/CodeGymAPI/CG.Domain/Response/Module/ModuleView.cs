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
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string CreateDateStr { get; set; }
        public string ModifiedDateStr { get; set; }
    }
}
