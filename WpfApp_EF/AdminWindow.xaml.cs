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
using System.Xml.Linq;

namespace WpfApp_EF
{
    public partial class AdminWindow : Window
    {
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();
        //new
        bool is_loaded_product_completed = false;
        Category selected_category = null;
        

        public AdminWindow()
        {
            InitializeComponent();
            is_loaded_product_completed = false;
            LoadCategoriesAndProductsIntoTreeView();
            is_loaded_product_completed = true;
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

        

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(is_loaded_product_completed == false)
            {
                //Không cho phép người dùng chọn sản phẩm khi chưa load xong
                return;
            }
            if(e.AddedItems.Count <= 0 )
            {
               //Không có sản phẩm nào được chọn
                return;
            }
            Product p = e.AddedItems[0] as Product;
            txtId.Text = p.ProductId.ToString();
            txtName.Text = p.ProductName.ToString();
            txtPrice.Text = p.UnitPrice.ToString();
            txtQuantity.Text = p.UnitsInStock.ToString();

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            is_loaded_product_completed = false;
            selected_category = null;
            if (e.NewValue == null)
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
            else if (data is Category)
            {
                //Người dùng nhấn vào node cate
                // => hiển thị sản phẩm của Danh mục vào list view 
                Category cate = data as Category;
                selected_category = cate;
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
            is_loaded_product_completed = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtId.Focus();
        }

        //Thêm sản phẩm mới
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Lấy danh mục ra
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item == null || selected_category == null)
                {
                    MessageBox.Show("Quá gà, chưa chọn danh mục sao thêm mới được???", "Lỗi chưa chọn Category",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //tạo 1 đối tượng product
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitsInStock = short.Parse(txtQuantity.Text);
                p.UnitPrice = decimal.Parse(txtPrice.Text);
                p.CategoryId = selected_category.CategoryId;
                bool ret = productService.SaveProduct(p);
                if (ret == true)
                {
                    //lưu thành công, nạp lại TreeView + ListView
                    //Nạp lên Tree
                    TreeViewItem p_node = new TreeViewItem();
                    p_node.Header = p.ProductName;
                    p_node.Tag = p;
                    cate_item.Items.Add(p_node);
                    //Nạp lại ListView
                    var products = productService
                        .GetProductsByCategory(selected_category.CategoryId);
                    is_loaded_product_completed = false;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_loaded_product_completed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi con ơi" + ex.Message,
                                "Save Error",
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);    
            }
        }
        

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Lấy danh mục ra
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item == null || selected_category == null)
                {
                    MessageBox.Show("Quá gà, chưa chọn danh mục sao sửa được???", "Lỗi chưa chọn Category",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //tạo 1 đối tượng product
                Product p = new Product();
                p.ProductId = int.Parse(txtId.Text);
                p.ProductName = txtName.Text;
                p.UnitsInStock = short.Parse(txtQuantity.Text);
                p.UnitPrice = decimal.Parse(txtPrice.Text);
                p.CategoryId = selected_category.CategoryId;
                bool ret = productService.UpdateProduct(p);
                if (ret == true)
                {
                    //cập nhật thành công, nạp lại cây
                    
                    is_loaded_product_completed = false;
                    cate_item.Items.Clear();
                    //Nạp lại ListView
                    var products = productService
                        .GetProductsByCategory(selected_category.CategoryId);
                    foreach (var product in products)
                    {
                        TreeViewItem p_item = new TreeViewItem();
                        p_item.Header = product.ProductName;
                        p_item.Tag = product;
                        cate_item.Items.Add(p_item);
                    }
                    is_loaded_product_completed = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi rồi con ơi" + ex.Message,
                                "Update Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //phải xác thực hỏi muốn xoá hay không
            int productId = int.Parse(txtId.Text);
            //tiến hành xoá
            bool ret = productService.DeleteProduct(productId);
            if(ret == true)
            {
                //Xoá thành công thì nạp lại treeview + listview
                if (selected_product_node != null)
                {
                    //xoá node product đang chọn và trong listview
                }
                else
                {
                    //nạp lại products list cho Cate node và ListView
                }
            }
        }

        
    }
}
