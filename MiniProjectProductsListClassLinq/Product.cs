using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectProductsListClassLinq
{
    public class Product
    {
        public Product(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
