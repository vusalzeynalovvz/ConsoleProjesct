﻿using ConsoleApp1.Data.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{

    public class Sales : BaseEntity
    {
        private static int count = 0;

        public Sales(decimal price, int salesİtem, string? date)
        {
            Price = price;
            Salesİtem = salesİtem;
            Date = date;

            Id= count++;
            count++;
        }
        public decimal Price { get; set; }
        public int Salesİtem { get; set; }
        public string? Date { get; set; }
    }
}