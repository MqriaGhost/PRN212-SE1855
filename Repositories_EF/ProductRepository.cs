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
        public List<Product> GetAllProducts()
        {
            return productDao.GetAllProducts();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return productDao.GetProductsByCategory(cateId);
        }
    }
}
