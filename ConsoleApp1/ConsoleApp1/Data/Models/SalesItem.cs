using ConsoleApp1.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{
    public class SalesItem : BaseEntity
    {
        private static int count = 0;

        public SalesItem(string? name, int count)
        {
            Name = name;
            Count = count;
            
            Id = count;
            count++;
        }

        public string? Name { get; set; }
        public int Count { get; set; }
    }
}
