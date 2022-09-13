using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturingProject.Models
{
    public class ProductDetails
    {
        public int PId { get; set; }
        public string P_Name { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public double cost { get; set; }
    }
}
