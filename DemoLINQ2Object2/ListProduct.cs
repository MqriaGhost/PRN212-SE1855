using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2Object2
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_products()
        {
            products.Add(new Product { Id = 1, Name = "Apple", Quantity = 12, Price = 1.2 });
            products.Add(new Product { Id = 2, Name = "Banana", Quantity = 20, Price = 0.5 });
            products.Add(new Product { Id = 3, Name = "Cherry", Quantity = 15, Price = 2.0 });
            products.Add(new Product { Id = 4, Name = "Date", Quantity = 5, Price = 3.0 });
            products.Add(new Product { Id = 5, Name = "Elderberry", Quantity = 9, Price = 4.0 });
            products.Add(new Product { Id = 6, Name = "VanTrang", Quantity = 10, Price = 90 });
            products.Add(new Product { Id = 7, Name = "VanDen", Quantity = 20, Price = 70 });
            products.Add(new Product { Id = 8, Name = "JVEvermind", Quantity = 15, Price = 250 });
            products.Add(new Product { Id = 9, Name = "ThanhUyen", Quantity = 11, Price = 300 });
            products.Add(new Product { Id = 10, Name = "YenNhi", Quantity = 22, Price = 100 });
        }
        public List<Product> FilterProductsByPrice(double price1, double price2)
        {
            return products.Where(p => p.Price >= price1 && p.Price <= price2)
                .ToList();
        }
        public List<Product> FilterProductsByPrice2(double price1, double price2)
        {
            var results = from p in products
                        where p.Price >= price1 && p.Price <= price2
                        select p;
            return results.ToList();
        }
        public List<Product> SortProductsByPriceDescending()
        {
            return products
                .OrderByDescending(p => p.Price)
                .ToList();
        }
        public List<Product> SortProductsByPriceDescending2()
        {
            var results = from p in products
                          orderby p.Price descending
                          select p;
            return results.ToList();
        }
        public double SumOfValue()
        {
            return products.Sum(p => p.Quantity * p.Price);
        }
    }
}
