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
        public List<Product> products; 
        public List<Sales> sales;
        public void AddProduct(string name, decimal price, Categories categories, int count)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (price==null) throw new Exception("price is null!");
            if (count==null) throw new Exception("count is null!");
           

            Product product = new Product
            {
                Name = name,
                Price = price,
                Categories = categories,
                Count= count
            };
            products.Add(product);
        }

        public void AddSales(List<int> ProductIds, List<int> SaleCounts)
        {
            if (ProductIds==null & SaleCounts ==null & ProductIds.Count!=SaleCounts.Count & ProductIds.Count==0 & SaleCounts.Count==0)
            {
                throw new Exception("Sale must contain at least one product with their quantity!");
            }
            decimal totalPrice = 0;
            List<SalesItem> saleItems = new List<SalesItem>();

            for (int i = 0; i < ProductIds.Count; i++)
            {
                int productId = ProductIds[i];
                int saleCount = SaleCounts[i];
                Product product = products.Find(m => m.Id == productId);
                if (product==null)
                {
                    throw new Exception($"Product Id {productId} is not found!");
                }
                if (product.Count< saleCount)
                {
                    throw new Exception("Quantity that you want to add is more than product's quantity");
                }
                 totalPrice = product.Price * saleCount;
                SalesItem salesItem = new SalesItem
                {
                    Product=product,
                    SaleItemCount = saleCount
                };
                 saleItems.Add(salesItem);
                product.Count-= saleCount;

            }
            Sales newSales = new Sales
            {
                Price = totalPrice,
                Salesİtem = saleItems,
                Date = DateTime.Now
            };
            sales.Add(newSales);
        }

  
        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Sales> GetSales()
        {
            throw new NotImplementedException();
        }

        public Sales GetSalesById(int saleId)
        {
            throw new NotImplementedException();
        }

        public List<Sales> GetSalesForDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Sales> GetSalesForDateInterval(DateTime froDate, DateTime ToDate)
        {
            throw new NotImplementedException();
        }

        public List<Sales> GetSalesForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public int ReturnProductFromSale(int SaleId, int ProductId)
        {
            throw new NotImplementedException();
        }

        public int ReturnSale(int SaleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(string NewName, decimal NewPrice, Categories NewCategories, int id)
        {
            throw new NotImplementedException();
        }

        public int UptadeProduct(string name, decimal price, Categories categories, int count)
        {
            throw new NotImplementedException();
        }
    }
}
