using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDao = new ProductDAO();

        public bool DeleteProduct(int productId)
        {
            return productDao.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return productDao.GetAllProducts();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return productDao.GetProductsByCategory(cateId);
        }

        public bool SaveProduct(Product product)
        {
            return productDao.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return productDao.UpdateProduct(product);
        }
    }
}
