using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product() { Id=1,Name="Coca",Quantity=10,Price=100});
            products.Add(new Product() { Id = 2, Name = "Pepsi", Quantity = 20, Price = 200 });
            products.Add(new Product() { Id = 3, Name = "Sting", Quantity = 15, Price = 500 });
            products.Add(new Product() { Id = 4, Name = "Redbull", Quantity = 10, Price = 300 });
            products.Add(new Product() { Id = 5, Name = "Lavie", Quantity = 30, Price = 400 });
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public bool SaveProduct(Product product)
        {
            Product old=products.FirstOrDefault(p=>p.Id==product.Id);
            if (old != null)
                return false;//vì trùng mã nên ko phải thêm mới
            //thêm mới:
            products.Add(product);
            return true;
        }
    }
}
