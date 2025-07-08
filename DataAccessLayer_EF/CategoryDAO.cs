using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class CategoryDAO
    {
        MyStoreContext context = new MyStoreContext();
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
    }
}
