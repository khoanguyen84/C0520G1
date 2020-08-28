using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.Entities
{
    public class Ward
    {
        [Key]
        public int id { get; set; }
        public string _name { get; set; }
        public string _prefix { get; set; }
        [ForeignKey("Province")]
        public int _province_id { get; set; }
        [ForeignKey("District")]
        public int _district_id { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
        public string WardName => $"{_prefix} {_name}";
    }
}
