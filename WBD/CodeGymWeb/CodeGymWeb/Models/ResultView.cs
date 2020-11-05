using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models
{
    public class ResultView
    {
        public DateTime CreatedtDate { get; set; }
        public string CreatedDateStr { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByStr { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateStr { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByStr { get; set; }
    }
}
