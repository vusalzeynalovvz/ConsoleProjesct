using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Making corrections on products");
                Console.WriteLine("2. Make adjustments to sales");
                Console.WriteLine("3. Exit");

                Console.WriteLine("----------------");
                Console.WriteLine("Enter an option please:");
                Console.WriteLine("----------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
                }

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
