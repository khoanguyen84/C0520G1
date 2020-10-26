using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Module
{
    public class CreateModuleView
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
