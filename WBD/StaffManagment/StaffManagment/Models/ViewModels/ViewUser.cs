using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.ViewModels
{
    public class ViewUser : ExtendIdentityUser
    {
        public string RoleName { get; set; }
    }
}
