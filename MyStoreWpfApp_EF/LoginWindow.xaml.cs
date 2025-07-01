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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }

        private void ChangeBackground()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
            brush.GradientStops.Add(new GradientStop(Colors.LightBlue, 0.5));
            btnThoat.Background = brush;

            RadialGradientBrush gradientBrush = new RadialGradientBrush();
            gradientBrush.GradientOrigin = new Point(0.5, 0.5);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LightBlue, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.5));
            btnDangNhap.Background = gradientBrush;
        }
        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
