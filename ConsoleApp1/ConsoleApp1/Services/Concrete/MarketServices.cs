using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using ConsoleApp1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Concrete
{
    public class MarketServices : IMarketable
    {
        public List<Product> products = new();
        public List<Sales> sales = new();

        public int AddProduct(string name, decimal price, Categories categories, int count)
        {
            // Check if the parameters are null, empty, or contains only white spaces
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (price == null) throw new Exception("price is null!");
            if (count == null) throw new Exception("count is null!");

            // Create a new 'Product' object with the provided parameters
            Product product = new Product
            {
                Name = name,
                Price = price,
                Categories = categories,
                Count = count
            };
            // Add the new 'product' to the 'products' list
            products.Add(product);
            // Return the 'Id' property of the newly added product
            return product.Id;
        }
        public void AddSales(List<int> ProductIds, List<int> SaleCounts)
        {
            // Check if the input lists are null, have different counts, and are empty
            if (ProductIds == null & SaleCounts == null & ProductIds.Count != SaleCounts.Count & ProductIds.Count == 0 & SaleCounts.Count == 0)
            {
                throw new Exception("Sale must contain at least one product with their quantity!");
            }
            // Initialize a variable to hold the total price of the sales
            decimal totalPrice = 0;

            // Initialize a list to store the sales items
            List<SalesItem> saleItems = new List<SalesItem>();

            // Loop through the ProductIds list to process each sale
            for (int i = 0; i < ProductIds.Count; i++)
            {
                // Get the ProductId and SaleCount for the current iteration
                int productId = ProductIds[i];
                int saleCount = SaleCounts[i];

                // Find the corresponding product in the 'products' list
                Product product = products.Find(m => m.Id == productId);

                // Check if the product with the given productId is found
                if (product == null)
                {
                    throw new Exception($"Product Id {productId} is not found!");
                }

                // Check if the sale count is greater than the available quantity of the product
                if (product.Count < saleCount)
                {
                    throw new Exception("Quantity that you want to add is more than product's quantity");
                }
                // Calculate the total price for the current sales item
                totalPrice += (decimal)(product.Price * saleCount);

                // Create a new SalesItem object for the current sale and add it to the list
                SalesItem salesItem = new SalesItem
                {
                    Product = product,
                    SaleItemCount = saleCount
                };
                saleItems.Add(salesItem);

                // Decrease the product count by the saleCount
                product.Count -= saleCount;

            }
            // Create a new Sales object to save the overall sales information
            Sales newSales = new Sales
            {
                Price = totalPrice,
                Salesİtem = saleItems,
                Date = DateTime.Now
            };
            sales.Add(newSales);
        }
        public void DeleteProduct(int id)
        {
            // Check if the id is null 
            if (id == null) throw new Exception("id is null");

            // Find the product with the given 'id' in the 'products' list 
            Product product = products.Find(m => m.Id == id);

            // Check if the product with the given 'id' is found in the list
            if (product == null) throw new Exception("Product is not found");

            // Remove the found product from the 'products' list
            products.Remove(product);

        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public List<Product> GetProductsByCategory(Categories categoryName)
        {
            // Check if the 'categoryName' parameter is null
            if (categoryName == null) throw new Exception("Category is null");

            // Find all products in the 'products' list that match the given 'categoryName'
            List<Product> ProductCategory = products.FindAll(m => m.Categories == categoryName);
            return ProductCategory;
        }
        public List<Product> GetProductsByName(string name)
        {
            // Check if the 'name' parameter is nul
            if (name == null) throw new Exception("name is null");

            // Find all products in the 'products' that contain the given 'name' 
            List<Product> ProductName = products.FindAll(m => m.Name.Contains(name));
            return ProductName;
        }
        public List<Product> GetProductsForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            // Check if the 'minPrice' and 'maxPrice' parameters are null
            if (minPrice == null) throw new Exception("minimum Price is null");
            if (maxPrice == null) throw new Exception("maximum Price is null");

            // Check if 'minPrice' is greater than 'maxPrice'
            if (minPrice > maxPrice) throw new Exception("Min Price is grater than Max Price!");

            // Find all products in the 'products' list that have a price greater than 'minPrice' and less than 'maxPrice'
            List<Product> productsForPrice = products.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return productsForPrice;
        }
        public List<Sales> GetSales()
        {
            return sales;
        }
        public Sales GetSalesById(int saleId)
        {
            // Check if the 'saleId' parameter is null 
            if (saleId == null) throw new Exception("sale Id is null");

            // Find the sales with the given 'saleId' in the 'sales' list
            Sales sale = sales.Find(s => s.Id == saleId);


            // Check if the sale with the given 'saleId' is found in the list
            if (sale == null) throw new Exception("Sale is not founf");
            return sale;
        }
        public List<Sales> GetSalesForDate(DateTime dateTime)
        {
            // Check if the 'dateTime' parameter is null 
            if (dateTime == null) throw new Exception("Date is null");

            // Filter the 'sales' list to find all sales that occurred on the specified 'dateTime'
            List<Sales> result = sales.Where(x => x.Date.Date == dateTime.Date).ToList();


            // Check if any sales were found for the given 'dateTime'
            if (result.Count == 0) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForDateInterval(DateTime FirstDate, DateTime LastDate)
        {
            // Check if 'FirstDate' is greater than 'LastDate'
            if (FirstDate > LastDate) throw new Exception("Min date is grater than last date!");

            // Filter the 'sales' list to find all sales that occurred within the specified date interval
            List<Sales> result = sales.Where(x => x.Date.Date >= FirstDate.Date && x.Date.Date <= LastDate.Date).ToList();

            // Check if any sales were found for the given date interval
            if (result == null) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            // Check if the 'minPrice' and 'maxPrice' parameters are 
            if (minPrice == null) throw new Exception("minimum Price is null");
            if (maxPrice == null) throw new Exception("maximum Price is null");

            // Check if the 'minPrice' is greater than 'maxPrice'
            if (minPrice > maxPrice)
            {
                throw new Exception("Minimum price is greater than maximum price!");
            }

            // Filter the 'sales' list to find all sales with a price within the specified interval
            List<Sales> salesForPrice = sales.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return salesForPrice;
        }
        public void ReturnProductFromSale(int SaleId, int ProductId, int count)
        {
            // Find the sale with the given 'SaleId' in the 'sales' list
            Sales sale = sales.Find(s => s.Id == SaleId);

            // Check if the sale with the given 'SaleId' is found in the list
            if (sale == null) throw new Exception("Sale is not found");

            // Find the sales item (product) with the given 'ProductId' in the sale
            SalesItem salesItem = sale.Salesİtem.Find(s => s.Id == ProductId);

            // Check if the product with the given 'ProductId' is found in the sale
            if (salesItem == null) throw new Exception("Product in Sale is not found");

            //Check if the requested 'count' is greater than the available quantity of the product in the sale
            if (count > salesItem.SaleItemCount) throw new Exception("Quantity must not more than product's count");

            // Calculate the refund amount for the returned product quantity
            decimal refundamount = (decimal)(count * salesItem.Product.Price);

            //Update count and price for returned values
            salesItem.Product.Count += count;
            salesItem.SaleItemCount -= count;
            sale.Price -= refundamount;



        }
        public void DeleteSale(int SaleId)
        {
            // Check if the 'SaleId' parameter is null
            if (SaleId == null) throw new Exception("id is null");

            // Find the sale with the given 'SaleId' in the 'sales' list
            Sales sale = sales.Find(m => m.Id == SaleId);

            // Check if the sale with the given 'SaleId' is found in the list
            if (sale == null) throw new Exception("Sale is not found");

            // Remove the found sale from the 'sales' list
            sales.Remove(sale);

        }
        public void UpdateProduct(string NewName, decimal NewPrice, int NewCount, Categories NewCategories, int id)
        {
            // Check if the 'id' parameter is null
            if (id == null) throw new Exception("Id is null!");

            // Find the product with the given 'id' in the 'products' list
            Product singleProduct = products.Find(s => s.Id == id);

            // Check if the product with the given 'id' is found in the list
            if (singleProduct == null)
            {
                throw new Exception("Product is not Found");
            }

            // Check if 'NewName', 'NewPrice' and 'NewCount' are null
            if (NewName == null) throw new Exception("New name is null!");
            if (NewPrice == null) throw new Exception("New Price is null!");
            if (NewCount == null) throw new Exception("New Count is null!");

            // Update the properties of the product with the new values
            singleProduct.Name = NewName;
            singleProduct.Price = NewPrice;
            singleProduct.Categories = NewCategories;
            singleProduct.Count = NewCount;
        }
    }
}
