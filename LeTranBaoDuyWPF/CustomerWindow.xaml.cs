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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        CustomerService customerService = new CustomerService();
        private List<Customer> customers = new();
        public CustomerWindow()
        {
            InitializeComponent();
            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            customers = customerService.GetCustomers();
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = customers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new CustomerEditWindow();
            if (addWindow.ShowDialog() == true) // ShowDialog sẽ trả về true nếu người dùng nhấn OK
            {
                var newCustomer = addWindow.GetCustomer();
                customerService.AddCustomer(newCustomer);
                LoadCustomerList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var editWindow = new CustomerEditWindow(dgCustomers.SelectedItem as Customer);
            if (editWindow.ShowDialog() == true)
            {
                var updatedCustomer = editWindow.GetCustomer();
                customerService.UpdateCustomer(updatedCustomer); // Cập nhật khách hàng
                LoadCustomerList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = dgCustomers.SelectedItem as Customer; // 'as' có thể hiểu là ép kiểu đối tượng
                                                                         // , nếu không thành công sẽ trả về null
            if (selectedCustomer != null)
            {
                var ret = MessageBox.Show($"Are you sure you want to delete customer {selectedCustomer.CompanyName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (ret == MessageBoxResult.No)
                {
                    return;
                }
                bool isDeleted = customerService.DeleteCustomer(selectedCustomer);
                if (isDeleted)
                {
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomerList();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var ret = MessageBox.Show("Are you sure you want to go back?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                var mainWindow = new AdminMainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var result = customers.Where(c =>
                        (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrEmpty(c.ContactName) && c.ContactName.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrEmpty(c.Phone) && c.Phone.ToLower().Contains(keyword)))
                .ToList();
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = result;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = customers; 
        }
    }
}
