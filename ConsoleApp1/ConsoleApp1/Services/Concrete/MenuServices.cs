using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
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
                var allproducts= marketServices.GetProducts();
                Console.WriteLine("All Products");
                foreach (Product item in allproducts)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
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
                Console.WriteLine("Please write product Id which you want to update");
                string ProductID=Console.ReadLine();
                int.TryParse(ProductID, out int ID);

                Console.WriteLine("Please Add New name");
                var NewName=Console.ReadLine();

                Console.WriteLine("Enter New price:");
                string Newprice = Console.ReadLine();
                decimal NewPriceProduct = decimal.Parse(Newprice);

                Console.WriteLine("Enter new count:");
                string Newcount = Console.ReadLine();
                int.TryParse(Newcount, out int NewCountProduct);

                Console.WriteLine("Enter Category:");
                Categories Newcategories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);
                marketServices.UpdateProduct(NewName,NewPriceProduct, NewCountProduct,Newcategories,ID);
                Console.WriteLine( "Product Updated Successfully");

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
                Console.WriteLine("Please write Product Id which you want to ddelete");
               string ProductID=Console.ReadLine();
                int.TryParse(ProductID, out int ID);
                marketServices.DeleteProduct(ID);
                Console.WriteLine("product deleted successfully");
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
        public static void MenuGetProductsByCategory()
        {
            Console.WriteLine("Please choose the  Category Name");
            foreach (Categories categoryy in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{categoryy}");
            }
            Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);
            marketServices.GetProductsByCategory(categories);
            
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
                var sales =marketServices.GetSales();
                Console.WriteLine("All Sales");
                foreach (var item in sales)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                }
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
