using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Lambda.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Category Category { get; set; }

        

        public override string ToString()
        {
            return $"{Id}\t{Name}    \t{Price:C}    \t{Category.Name}    \t{Category.Tier}";
        }
    }
}
