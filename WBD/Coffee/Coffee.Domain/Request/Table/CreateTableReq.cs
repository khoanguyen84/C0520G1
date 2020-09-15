using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Coffee.Domain.Request.Table
{
    public class CreateTableReq
    {
        [MaxLength(20)]
        [Required]
        public string TableCode { get; set; }
    }
}
