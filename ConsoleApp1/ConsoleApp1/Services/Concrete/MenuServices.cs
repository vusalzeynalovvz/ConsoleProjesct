using ConsoleApp1.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Concrete
{
    public class MenuServices
    {
        public static MarketServices marketServices = new MarketServices();



        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                string price = Console.ReadLine();
                decimal PriceProduct = decimal.Parse(price);

                Console.WriteLine("Enter count:");
                string count = Console.ReadLine();
                int.TryParse(count, out int CountProduct);

                Console.WriteLine("Enter Category:");
                Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

                int newId= marketServices.AddProduct(name, PriceProduct, categories, CountProduct);
                Console.WriteLine("Product Added Successfully");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuUptadeProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuFindCategories()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuRangePrice()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuFindProductName()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuAddSales()
        {
            try
            {
                Console.WriteLine("Enter Product Ids:");
                string productIdsInput = Console.ReadLine();
                List<int> productIds = productIdsInput.Split(',').Select(int.Parse).ToList();


                Console.WriteLine("Enter Sale Counts:");
                string saleCountsInput = Console.ReadLine();
                List<int> saleCounts = saleCountsInput.Split(',').Select(int.Parse).ToList();
                if (saleCounts.Count!= productIds.Count)
                {
                    throw new Exception("The number of product Ids and sale counts must be same");
                }

                marketServices.AddSales(productIds, saleCounts);
                Console.WriteLine("Sale Added Successfully");


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuReturnProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDeleteSales() 
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowSales()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDatetimeSales()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuPriceRangeShow()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDateSale()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuFindSales()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}
