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

namespace LeTranBaoDuyWPF
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customerWindow = new CustomerWindow();
            customerWindow.Show();
            this.Hide(); 
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductWindow();
            productWindow.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var reportWindow = new ReportWindow();
            reportWindow.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var ret = MessageBox.Show("Are you sure want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(ret == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
