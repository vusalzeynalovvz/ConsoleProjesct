using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
                Console.WriteLine("Enter name:  ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:  ");
                string price = Console.ReadLine();
                // Parse the price as a decimal
                decimal PriceProduct = decimal.Parse(price);

                Console.WriteLine("Enter count:  ");
                string count = Console.ReadLine();
                // Try to parse the count as an integer using 'int.TryParse'
                int.TryParse(count, out int CountProduct);

                Console.WriteLine("Enter Category  :");

                // Display all available category names
                foreach (Categories categoryy in Enum.GetValues(typeof(Categories)))
                {
                    Console.WriteLine($"{categoryy}");
                }
                // Parse the user input as an enum value of the 'Categories' enumeration
                Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

                // Call the 'AddProduct' method from the 'marketServices' instance to add the product
                int newId = marketServices.AddProduct(name, PriceProduct, categories, CountProduct);

                // Display a success message after adding the product
                Console.WriteLine("Product Added Successfully");
            }
            catch (Exception ex)
            {

                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProduct()
        {
            try
            {
                // Call the 'GetProducts' method from the 'marketServices' instance to fetch all products
                var allproducts = marketServices.GetProducts();
                
                // Loop through each product in the 'allproducts' list and display its details
                foreach (Product item in allproducts)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
            }
            catch (Exception ex)
            {

                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuUptadeProduct()
        {
            try
            {
                Console.WriteLine("Please write product Id which you want to update");
                string ProductID = Console.ReadLine();
                // Parse the product ID as an integer using 'int.TryParse'
                int.TryParse(ProductID, out int ID);

                Console.WriteLine("Please Add New name");
                var NewName = Console.ReadLine();

                Console.WriteLine("Enter New price:");
                string Newprice = Console.ReadLine();
                // Parse the new price as a decimal
                decimal NewPriceProduct = decimal.Parse(Newprice);

                Console.WriteLine("Enter new count:");
                string Newcount = Console.ReadLine();
                int.TryParse(Newcount, out int NewCountProduct);

                Console.WriteLine("Enter Category:");
                // Parse the user input as an enum value of the 'Categories' enumeration
                Categories Newcategories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

                // Call the 'UpdateProduct' method from the 'marketServices' instance to update the product
                marketServices.UpdateProduct(NewName, NewPriceProduct, NewCountProduct, Newcategories, ID);

                // Display a success message after updating the product
                Console.WriteLine("Product Updated Successfully");

            }
            catch (Exception ex)
            {

                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Please write Product Id which you want to ddelete");
                string ProductID = Console.ReadLine();
                int.TryParse(ProductID, out int ID);

                // Call the 'DeleteProduct' method from the 'marketServices' instance to delete the product
                marketServices.DeleteProduct(ID);
                // Display a success message after deleting the product
                Console.WriteLine("product deleted successfully");
            }
            catch (Exception ex)
            {

                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuRangePrice()
        {
            try
            {
                Console.WriteLine("Please write minimum Price");
                string minimum = Console.ReadLine();
                decimal minimumPrice = decimal.Parse(minimum);

                Console.WriteLine("Please write maximum Price");
                string maximum = Console.ReadLine();
                decimal maximumPrice = decimal.Parse(maximum);

                // Call the 'GetProductsForPriceInterval' method from the 'marketServices' instance to get products within the specified price range
                var ProductsPriceInterval = marketServices.GetProductsForPriceInterval(minimumPrice, maximumPrice);

                // Display the products within the price range
                foreach (var item in ProductsPriceInterval)
                {
                    // Handle any exceptions that may occur during the process and display an error message
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuGetProductsByCategory()
        {
            Console.WriteLine("Please choose the  Category Name");

            // Display all available category names
            foreach (Categories categoryy in Enum.GetValues(typeof(Categories)))
            {
              Console.WriteLine($"{categoryy}");
            }  

            // Parse the user input as an enum value of the 'Categories' enumeration
            Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

            // Call the 'GetProductsByCategory' method from the 'marketServices' instance to get products for the selected category
            var procategory = marketServices.GetProductsByCategory(categories);
            // Display the products belonging to the selected category
            foreach (var item in procategory)
            {

                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
            }

        }
        public static void MenuFindProductName()
        {
            try
            {
                Console.WriteLine("Please write the text for search");
                string ProductSearch = Console.ReadLine();

                // Call the 'GetProductsByName' method from the 'marketServices' instance to get products that match the search query
                var Search = marketServices.GetProductsByName(ProductSearch);

                // Display the matched products to the console
                foreach (var item in Search)
                {
                    // Handle any exceptions that may occur during the process and display an error message
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }

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
                // Convert the comma-separated input into a List of integers (Product IDs)
                List<int> productIds = productIdsInput.Split(',').Select(int.Parse).ToList();


                Console.WriteLine("Enter Sale Counts:");
                string saleCountsInput = Console.ReadLine();
                // Convert the comma-separated input into a List of integers (Sale Counts)
                List<int> saleCounts = saleCountsInput.Split(',').Select(int.Parse).ToList();

                // Check if the number of product IDs and sale counts is the same
                if (saleCounts.Count != productIds.Count)
                {
                    throw new Exception("The number of product Ids and sale counts must be same");
                }
                // Call the 'AddSales' method from the 'marketServices' instance to add the sale
                marketServices.AddSales(productIds, saleCounts);

                // Display a success message after adding the sale
                Console.WriteLine("Sale Added Successfully");


            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuReturnProduct()
        {
            try
            {
                Console.WriteLine("Please write which sale you want to update ");
                string saleIdsInput = Console.ReadLine();
                int.TryParse(saleIdsInput, out int saleId);

                Console.WriteLine("Please write which product you want to return");
                string productIdsInput = Console.ReadLine();
                int.TryParse(productIdsInput, out int productId);

                Console.WriteLine("Please write how many product you want to return");
                string productCountInput = Console.ReadLine();
                int.TryParse(productCountInput, out int productCount);
                // Call the 'ReturnProductFromSale' method from the 'marketServices' instance to return the product from the sale
                marketServices.ReturnProductFromSale(saleId, productId, productCount);

                // Display a success message after returning the product
                Console.WriteLine("Product returned successfully");


            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteSales()
        {
            try
            {
                Console.WriteLine("Please write Sale Id which you want to delete");
                string SaleID = Console.ReadLine();
                int.TryParse(SaleID, out int ID);

                // Call the 'DeleteSale' method from the 'marketServices' instance to delete the sale
                marketServices.DeleteSale(ID);

                // Display a success message after deleting the sale
                Console.WriteLine("Sale deleted successfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowSales()
        {
            try
            {
                // Call the 'GetSales' method from the 'marketServices' instance to get all sales
                var sales = marketServices.GetSales();
                Console.WriteLine("All Sales");
                // Loop through each sale and display its details
                foreach (var item in sales)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    // Loop through each sale item within the sale and display its details
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuGetSalesForPriceInteerval()
        {
            try
            {
                Console.WriteLine("Please write minimum Price");
                string minimum = Console.ReadLine();
                decimal minimumPrice = decimal.Parse(minimum);

                Console.WriteLine("Please write maximum Price");
                string maximum = Console.ReadLine();
                decimal maximumPrice = decimal.Parse(maximum);

                // Call the 'GetSalesForPriceInterval' method from the 'marketServices' instance to get sales within the specified price range
                var SalesPriceInterval = marketServices.GetSalesForPriceInterval(minimumPrice, maximumPrice);

                // Display the sales within the price range along with their details and sale items
                foreach (var item in SalesPriceInterval)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    // Loop through each sale item within the sale and display its details
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDateSale()
        {
            try
            {
                //user to enter the date in the format "dd/MM/yyyy"
                Console.WriteLine("Enter date (dd/MM/yyyy):");
                DateTime date = DateTime.Parse(Console.ReadLine());

                // Call the 'GetSalesForDate' method from the 'marketServices' instance to get sales on the specified date
                var SalesForDate = marketServices.GetSalesForDate(date);

                // Display the sales on the specified date with their details and sale items
                foreach (var item in SalesForDate)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    // Loop through each sale item within the sale and display its details
                    foreach (var saleitem in item.Salesİtem)
                    {
                        // Handle any exceptions that may occur during the process and display an error message
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");

                    }
                }
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

                Console.WriteLine("Please write which sale you want to see ");
                string saleIdsInput = Console.ReadLine();
                int.TryParse(saleIdsInput, out int saleId);

                // Call the 'GetSalesById' method from the 'marketServices' instance to get the details of the selected sale
                var SingleSale = marketServices.GetSalesById(saleId);
                // Display the details of the selected sale with its sale items
                Console.WriteLine($"{SingleSale.Id},{SingleSale.Price},{SingleSale.Date}");
                // Loop through each sale item within the sale and display its details
                foreach (var saleitem in SingleSale.Salesİtem)
                {
                    // Handle any exceptions that may occur during the process and display an error message
                    Console.WriteLine($"{saleitem.Product.Id},{saleitem.Product.Name},{saleitem.SaleItemCount}");

                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuFindSalesForDateInterval()
        {
            try
            {
                Console.WriteLine("Enter First date (dd/MM/yyyy):");
                DateTime Firstdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Last date (dd/MM/yyyy):");
                DateTime Lastdate = DateTime.Parse(Console.ReadLine());

                // Call the 'GetSalesForDateInterval' method from the 'marketServices' instance to get sales within the specified date interval
                var SalesForDateInterval = marketServices.GetSalesForDateInterval(Firstdate, Lastdate);

                // Display the sales within the date interval with their details and sale items
                foreach (var item in SalesForDateInterval)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    // Loop through each sale item within the sale and display its details
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");

                    }
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process and display an error message
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}
