using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Module
{
    public class SaveModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Status { get; set; }
        public int Duration { get; set; }
    }
}
