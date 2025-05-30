using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category()  
        { 
            Products = new Dictionary<int, Product>();
        }
        /*
         * Mọi dữ liệu ta cần làm đủ CRUD
         */
        public void AddProduct(Product p)
        {
            if (Products.ContainsKey(p.Id))
            {
                return; //vì mã tồn tại
            }
            Products.Add(p.Id, p);
        }
        //Xem toàn bộ Product của danh mục:
        public void PrintAllProducts()
        {
            foreach(KeyValuePair<int, Product> item in Products)
            {
                Product p = item.Value;
                Console.WriteLine(p);
            }
        }
        //Lọc ra các sản phẩm có giá trị từ x tới y
        public Dictionary<int, Product>FilterProductsByPrice(double min, double max)
        {
            Dictionary<int, Product> results = new Dictionary<int, Product>();
            results = Products.Where(item => item.Value.Price >= min && item.Value.Price <= max)
                .ToDictionary<int, Product>();
            return results;
        }
        //Sorting ascending by price
        public Dictionary<int, Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }

        /* Hãy sắp xếp sản phẩm theo đơn giá tăng dần
         * Nếu đơn giá trùng nhau thì sắp xếp theo số lượng giảm dần
         */
        public Dictionary<int, Product> ComplexSort()
        {
            return Products.OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>(); 
        }

        public bool UpdateProduct(Product p)
        {
            if (p == null)
            {
                return false; //không tìm thấy mã
            }
            if(Products.ContainsKey(p.Id) == false)
            {
                return false; //không tìm thấy mã
            }
            Products[p.Id] = p; //đè dữ liệu lên ô nhớ hiện tại, hoặc là tham chiếu ô nhớ
            return true; 
        }

        public bool RemoveProduct(int id)
        {
            if (Products.ContainsKey(id) == false) return false;
            return Products.Remove(id); 
            //trả về true nếu xóa thành công, false nếu không tìm thấy mã
        }
    }
}
