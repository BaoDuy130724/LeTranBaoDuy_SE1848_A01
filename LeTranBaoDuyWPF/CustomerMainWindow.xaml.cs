using BusinessObjects;
using Services;
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
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        OrderService orderService = new OrderService();
        CustomerService customerService = new CustomerService();
        private Customer currentCustomer;
        public CustomerMainWindow(Customer customerlogined)
        {
            InitializeComponent();
            currentCustomer = customerlogined;
            LoadCustomerProfile();
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            lvOrders.ItemsSource = null;
            lvOrders.ItemsSource = orderService.GetOrderByCustomerId(currentCustomer.CustomerId);
        }

        private void LoadCustomerProfile()
        {
            txtCompanyName.Text = currentCustomer.CompanyName;
            txtContactName.Text = currentCustomer.ContactName;
            txtContactTitle.Text = currentCustomer.ContactTitle;
            txtAddress.Text = currentCustomer.Address;
            txtPhone.Text = currentCustomer.Phone;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.CompanyName = txtCompanyName.Text;
            currentCustomer.ContactName = txtContactName.Text;
            currentCustomer.ContactTitle = txtContactTitle.Text;
            currentCustomer.Address = txtAddress.Text;
            bool updated = customerService.UpdateCustomer(currentCustomer);
            if (updated)
            {
                MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
