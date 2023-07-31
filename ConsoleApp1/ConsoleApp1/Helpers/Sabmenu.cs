using ConsoleApp1.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sabmenu
    {
        public static void ProductSabmenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Choose which operation you want to perform on the products!");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show Product");
                Console.WriteLine("5. Find For Categories");
                Console.WriteLine("6. Find Product For Price Range");
                Console.WriteLine("7. Find Product For Name");
                Console.WriteLine("0. Exit");


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
                        Console.Clear();
                        Console.WriteLine(" Add New Product!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuAddProduct();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Update Any Product!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuUptadeProduct();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(" Delete Any Product!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuDeleteProduct();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(" Show All Products!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuShowProduct();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(" Show Products By Category Name!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuGetProductsByCategory();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine(" Show Products For Price Interval!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuRangePrice();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine(" Show Products By Their Name!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuFindProductName();
                        break;
                    case 0:
                        Console.WriteLine(" Good bye!");
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }

        public static void SalesSubMenu()
        {
            int option;
            do
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Choose which operation you want to perform on the Sales!");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Add Sales");
                Console.WriteLine("2. Return Product From Sales");
                Console.WriteLine("3. Remove Sales");
                Console.WriteLine("4. Show Sales");
                Console.WriteLine("5. Show Sales For Price Interval");
                Console.WriteLine("6. Show Date Sales");
                Console.WriteLine("7. Finding sales by ID");
                Console.WriteLine("8. Show Sale For Date Interval");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add New Sale!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuAddSales();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Return Any Product From Sale!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuReturnProduct();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Delete Any Sale!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuDeleteSales();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Show All Sales!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuShowSales();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Show Sales For Price Interval!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuGetSalesForPriceInteerval();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Show Sale By Date!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuDateSale();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Show One Sale!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuFindSales();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Show Sale For Date Interval!");
                        Console.WriteLine("----------------");
                        MenuServices.MenuFindSalesForDateInterval();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
