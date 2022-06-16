using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceDemo.Models
{
    public class CategoryViewModel
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}