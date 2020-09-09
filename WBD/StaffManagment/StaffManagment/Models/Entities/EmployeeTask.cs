using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.Entities
{
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public Employee Employee { get; set; }
        public Task Task { get; set; }
    }
}
