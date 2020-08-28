using PeopleManagement.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models.ViewModels
{
    public class RegisterView : RegisterUser
    {
        public RegisterView()
        {
            Provinces = new List<Province>();
            Districts = new List<District>();
            Wards = new List<Ward>();
        }
        public List<Province> Provinces { get; set; }
        public List<District> Districts { get; set; }
        public List<Ward> Wards { get; set; }
    }
}
