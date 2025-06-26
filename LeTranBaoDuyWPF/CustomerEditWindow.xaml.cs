using BusinessObjects;
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
    /// Interaction logic for CustomerEditWindow.xaml
    /// </summary>
    public partial class CustomerEditWindow : Window
    {
        private Customer currentCustomer;
        private bool isEditMode; 
        public CustomerEditWindow(Customer customer = null)
        {
            InitializeComponent();
            if(customer == null)
            {
                currentCustomer = new Customer();
                isEditMode = false;
            }
            else
            {
                currentCustomer = new Customer
                {
                    CustomerId = customer.CustomerId,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    Phone = customer.Phone
                };
                isEditMode = true;
                loadData();
            }
            txtPhone.IsReadOnly = isEditMode;
        }

        private void loadData()
        {
            txtCompanyName.Text = currentCustomer.CompanyName;
            txtContactName.Text = currentCustomer.ContactName;
            txtContactTitle.Text = currentCustomer.ContactTitle;
            txtAddress.Text = currentCustomer.Address;
            txtPhone.Text = currentCustomer.Phone;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtCompanyName== null || txtContactName == null || txtContactTitle == null || txtAddress == null || txtPhone == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            currentCustomer.CompanyName = txtCompanyName.Text.Trim();
            currentCustomer.ContactName = txtContactName.Text.Trim();
            currentCustomer.ContactTitle = txtContactTitle.Text.Trim();
            currentCustomer.Address = txtAddress.Text.Trim();
            currentCustomer.Phone = txtPhone.Text.Trim();
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public Customer GetCustomer()
        {
            return currentCustomer;
        }
    }
}
