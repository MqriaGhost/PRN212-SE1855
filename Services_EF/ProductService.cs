using DataAccessLayer_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService()
        {
         productRepository = new ProductRepository();
        }
        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return productRepository.GetProductsByCategory(cateId);
        }
    }
}
