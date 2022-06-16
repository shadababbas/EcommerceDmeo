using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceDemo.Models
{
    public class StockViewModel
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public long Quantity { get; set; }
        public long OutStock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}