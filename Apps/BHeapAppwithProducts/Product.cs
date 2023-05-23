using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHeapAppwithProducts
{
    public class Product : IComparable
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            if (obj is Product otherProduct)
                return price.CompareTo(otherProduct.price);

            throw new ArgumentException("Object is not a Product");
        }
    }
}
