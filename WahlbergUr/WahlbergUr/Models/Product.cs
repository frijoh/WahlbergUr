using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WahlbergUr.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductInformation { get; set; }
        public string ProductUrl { get; set; }
     
    }
}
