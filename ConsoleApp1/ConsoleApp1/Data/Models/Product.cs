using ConsoleApp1.Data.Common;
using ConsoleApp1.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{
    public class Product : BaseEntity
    {
        private static int count = 0;

        public Product(string name, decimal price, Categories categories,int pcount )
        {
            Name= name;
            Price= price;
            Categories= categories;
            Pcount= pcount;

            Id= count++;
            count++;
        }

        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Categories Categories { get; set; }
        public int Pcount { get; set; }
    }
}
