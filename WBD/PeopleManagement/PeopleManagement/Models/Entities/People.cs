using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.Entities
{
    public class People
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        [ForeignKey("Ward")]
        public int WardId { get; set; }
        public string Address { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
        public Ward Ward { get; set; }
    }
}
