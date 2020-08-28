using PeopleManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.ViewModels
{
    public class ProvinceView
    {
        public ProvinceView()
        {
            Districts = new List<District>();
            Wards = new List<Ward>();
        }
        public List<District> Districts { get; set; }
        public List<Ward> Wards { get; set; }
    }
}
