using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.Entities
{
    public class District
    {
        [Key]
        public int id { get; set; }
        public string _name { get; set; }
        public string _prefix { get; set; }
        [ForeignKey("Province")]
        public int _province_id { get; set; }
        public Province Province { get; set; }
        public ICollection<Ward> Wards { get; set; }
        public string DistrictName => $"{_prefix} {_name}";
    }
}
