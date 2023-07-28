using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Abstract
{
    public interface IMarketable
    {
        public List<Sales> GetSales();
        public List<Product> GetProducts();
        public void AddSales(List<int> ProductIds, List<int> SaleCounts);
        public int ReturnProductFromSale(int SaleId, int ProductId);
        public int ReturnSale(int SaleId);
        public int UptadeProduct(string name, decimal price, Categories categories, int count);
        public List<Sales> GetSalesForDateInterval(DateTime froDate, DateTime ToDate);
        public List<Sales> GetSalesForDate(DateTime dateTime);
        public List<Sales> GetSalesForPriceInterval(decimal minPrice, decimal maxPrice);
        public Sales GetSalesById(int saleId);
        public int AddProduct(string name, decimal price, Categories categories, int count);
        public void UpdateProduct( string NewName, decimal NewPrice, Categories NewCategories,int id);
        public List<Product> GetProductsByCategory( string categoryName);
        public List<Product> GetProductsForPriceInterval(decimal minPrice, decimal maxPrice);
        public List<Product> GetProductsByName(string name);


     
    }
}
