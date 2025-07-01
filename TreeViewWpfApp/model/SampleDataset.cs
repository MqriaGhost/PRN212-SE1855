using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.model
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category electronics = new Category { Id = 1, Name = "Electronics" };          
            Category clothing = new Category { Id = 2, Name = "Clothing" };
            Category c3 = new Category { Id = 3, Name = "Food" };
            categories.Add(electronics.Id, electronics);
            categories.Add(clothing.Id, clothing);
            categories.Add(c3.Id, c3);
            return categories;
        }
    }
}
