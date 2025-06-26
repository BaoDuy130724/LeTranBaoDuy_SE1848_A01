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
    /// Interaction logic for OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        private OrderService orderService;
        private CustomerService customerService;
        private EmployeeService employeeService;
        private readonly bool isEditMode;
        private Order currentOrder;
        public OrderEditWindow(Order order = null)
        {
            InitializeComponent();
            orderService = new OrderService();
            customerService = new CustomerService();
            employeeService = new EmployeeService();
            LoadCmbData();
            if (order == null)
            {
                isEditMode = false;
                currentOrder = new Order();
                dpOrderDate.SelectedDate = DateTime.Now;
            }
            else
            {
                isEditMode = true;
                currentOrder = order;
                cmbCustomer.SelectedItem = customerService.GetCustomers().FirstOrDefault(c => c.CustomerId == order.CustomerId);
                cmbEmployee.SelectedItem = employeeService.GetEmployees().FirstOrDefault(e => e.EmployeeId == order.EmployeeId);
                dpOrderDate.SelectedDate = order.OrderDate;
            }

        }
        private void LoadCmbData()
        {
            cmbCustomer.ItemsSource = customerService.GetCustomers();
            cmbCustomer.DisplayMemberPath = "ContactName";
            cmbEmployee.ItemsSource = employeeService.GetEmployees();
            cmbEmployee.DisplayMemberPath = "Name";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var cus = cmbCustomer.SelectedItem as Customer;
            var emp = cmbEmployee.SelectedItem as Employee;
            var date = dpOrderDate.SelectedDate;
            if (cus == null || emp == null || date == null)
            {
                MessageBox.Show("Please select a customer, employee and order date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            currentOrder.CustomerId = cus.CustomerId;
            currentOrder.EmployeeId = emp.EmployeeId;
            currentOrder.OrderDate = date.Value;
            currentOrder.Customer = cus;
            currentOrder.Employee = emp;
            if (isEditMode)
            {
                if (orderService.UpdateOrder(currentOrder))
                {
                    MessageBox.Show("Order updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (orderService.AddOrder(currentOrder))
                {
                    MessageBox.Show("Order added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            DialogResult = true;
        }
        public Order GetOrder()
        {
            return currentOrder;
        }
    }
}
