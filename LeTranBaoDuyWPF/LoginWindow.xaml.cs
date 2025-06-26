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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        EmployeeService employeeService = new EmployeeService();
        CustomerService customerService = new CustomerService();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password.Trim();
            if (rdoAdmin.IsChecked == true)
            {
                var employeeLogined = employeeService.GetEmployeeLogin(username, password);
                if (employeeLogined != null)
                {
                    var admin = new AdminMainWindow(); // AdminMainWindow is the main window for admin
                    admin.Show(); // Show the main window
                    this.Hide(); // Hide the login window to logout and comeback this window
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!!!");
                }
            }
            else
            {
                var customerLogined = customerService.GetCustomerByPhone(username);
                if (customerLogined != null)
                {
                    var customer = new CustomerMainWindow(customerLogined);
                    customer.Show(); 
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("This phone number does not exist!!!");
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var ret = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                this.Close(); 
            }
        }
    }
}
