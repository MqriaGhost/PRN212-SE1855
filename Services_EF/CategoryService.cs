using DataAccessLayer_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repository;
        public CategoryService()
        {
         repository = new CategoryRepository();
        }
        public List<Category> GetAllCategories()
        {
            return repository.GetAllCategories();

        }
    }
}
