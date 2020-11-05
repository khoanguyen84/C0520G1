using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.ExHis
{
    public class ExecutionHistoryView
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int ElementId { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int ModifiedBy { get; set; }
    }
}
