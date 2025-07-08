using DataAccessLayer_EF;
using Repositories_EF;
using Services_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_EF
{
    public partial class AdminWindow : Window
    {
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesAndProductsIntoTreeView();
        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            tvCategory.Items.Clear();
            //Tạo gốc
            TreeViewItem root = new TreeViewItem();
            root.Header = "石村 STORAGE";
            tvCategory.Items.Add(root);
            //Nạp danh mục lên treeview
            List<Category> categories = categoryService.GetAllCategories();
            foreach(Category category in categories)
            {
                //Tạo cate node:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //nạp product theo danh mục cate
                List<Product> products = productService
                                        .GetProductsByCategory
                                        (category.CategoryId);
                category.Products = products;
                //Đưa product Node vào cate node
                foreach(Product product in category.Products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(e.NewValue == null)
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null) return;
            List<Product> products = null;
            object data = item.Tag;
            if (data == null)
            {
                //Người dùng nhấn vào node gốc
                //==> Hiển thị toàn bộ sản phẩm vào list view
                products = productService.GetAllProducts();
            }
            else if(data is Category)
            {
                //Người dùng nhấn vào node cate
                // => hiển thị sản phẩm của Danh mục vào list view 
                Category cate = data as Category;
                products = productService
                    .GetProductsByCategory(cate.CategoryId);
            }
            else if(data is Product)
            {
                //Hiển thị sản phẩm này vào list view
                Product product = data as Product;
                products = new List<Product>();
                products.Add(product);
            }
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
