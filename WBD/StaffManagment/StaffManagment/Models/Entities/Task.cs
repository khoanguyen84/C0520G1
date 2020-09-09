using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        [MaxLength(200)]
        public string TaskName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        public ICollection<EmployeeTask> TaskEmployees { get; set; }
    }
}
