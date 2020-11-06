using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Module
{
    public class ModuleChangeStatusRequest
    {
        public int ModuleId { get; set; }
        public int Status { get; set; }
        public int ModifiedBy { get; set; }
    }
}
