using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class ProductMdl
    {
        public int ProductCode { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string ProductCategory { get; set; }
        public int Qty { get; set; }
    }
}