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

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            //ta giả đò làm đăng nhập
            //nếu thành công thì vào mainwinow
            //nếu thất bại thì thông báo fail
            if(txtUsername.Text == "obama" && txtPassword.Text == "123")
            {
                //mở màn ihnhf mainwindow
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                //đóng cửa sổ đăng nhập
                Close();
            }
            else
            {
                //thông báo đăng nhập thất bại
                MessageBox.Show("Đăng nhập thất bại, vui lòng thử lại!");
            }
        }
    }
}
