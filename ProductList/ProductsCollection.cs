using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductList
{
    class Products
    {
        public Products(string symbol, string name, int count, string warehouse)
        {
            Symbol = symbol;
            Name = name;
            Count = count;
            Warehouse = warehouse;
        }

        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Warehouse { get; set; }


    }
}
