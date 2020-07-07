using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement
{
    class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Manufactory { get; set; }

        public string ShowProductInfo()
        {
            return $"{Name}\t{Code}\t{Price}\t{Date.ToString("ddd, MMM dd yyyy")}\t\t{Manufactory}";
        }
    }
}
