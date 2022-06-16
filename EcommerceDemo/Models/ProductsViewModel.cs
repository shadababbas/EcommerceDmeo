using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceDemo.Models
{
    public class ProductsViewModel
    {
        public long ID { get; set; }
        public long CategoryID { get; set; }
        public string ProductName { get; set; }
        public string CreatedDate { get; set; }
        public long Price { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductImageName { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }
    }
}