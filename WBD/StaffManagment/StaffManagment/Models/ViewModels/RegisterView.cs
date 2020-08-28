using StaffManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.ViewModels
{
    public class RegisterView : RegisterAdd
    {
        public RegisterView()
        {
            Provinces = new List<Province>();
            Districts = new List<District>();
            Wards = new List<Ward>();
        }
        
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<District> Districts { get; set; }
        public IEnumerable<Ward> Wards { get; set; }
    }
}
