using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class ProductModel
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Category { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime CratedDate { get; set; }

    }
}
