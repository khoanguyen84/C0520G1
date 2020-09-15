using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Coffee.Domain.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        [MaxLength(20)]
        [Required]
        public string TableCode { get; set; }
        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
