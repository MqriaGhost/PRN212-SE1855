using MyStoreWpfApp_EF.Models;
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

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            //Tạo Gốc cây:
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho Cát Lái";
            tvCategory.Items.Add(root);
            //Dùng EF Truy vấn toàn bộ danh mục và nạp lên Tree:
            var categories = context.Categories.ToList();
            foreach (var category in categories)
            {
                //Tạo node cho Danh mục:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //nạp danh sách Sản phẩm vào node danh mục:
                var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
                foreach (var product in products)
                {
                    //Tạo Product node:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
                return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            Category category = item.Tag as Category;
            if (category != null)
            {
                LoadProductsIntoListView(category);
            }
            Product product = item.Tag as Product;
            if (product != null)
            {
                var products = new List<Product>();
                products.Add(product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
            }

        }
        private void LoadProductsIntoListView(Category category)
        {
            var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }
        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            Product product = e.AddedItems[0] as Product;
            if (product == null) return;
            DisplayProductDetail(product);
        }

        private void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = string.Empty;
            }
            else
            {
                txtId.Text = product.ProductId + "";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock + "";
                txtPrice.Text = product.UnitPrice + "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Create product
            //Add product to cate
            //Save
            //UPdate View
            try
            {
                Product product = new Product
                {
                    ProductName = txtName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = short.Parse(txtQuantity.Text)
                };
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected == null)
                {
                    MessageBox.Show(
                        "Please select a category to add product.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                Category cate = cate_node_selected.Tag as Category;
                if (cate == null)
                {
                    MessageBox.Show(
                        "Please select a category to add product.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                product.CategoryId = cate.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                //Bước 4.2 cập nhật ListView (hiển thị sản phẩm)
                //vừa thêm csdl thành công trên giao diện:
                cate_node_selected.Items.Add(product_node);
                LoadProductsIntoListView(cate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi"+ ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Check if product exists
            //Update product
            //Save Product
            //Update View
            try
            {
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        "Product not found.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                product.ProductName = txtName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                context.SaveChanges();
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected != null)
                {
                    Category cate = cate_node_selected.Tag as Category;
                    if (cate != null)
                    {
                        cate_node_selected.Items.Clear();
                        var p = context.Products
                        .Where(p => p.CategoryId == cate.CategoryId)
                        .ToList();
                        foreach (var pro in p)
                        {
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = pro.ProductName;
                            product_node.Tag = pro;
                            cate_node_selected.Items.Add(product_node);
                        }
                        LoadProductsIntoListView(cate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Please enter valid data for product.",
                    "Error " + ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
