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
        private readonly List<Customer> customers;
        private readonly List<Employee> employees;
        public OrderEditWindow(Order order = null)
        {
            InitializeComponent();
            orderService = new OrderService();
            customerService = new CustomerService();
            employeeService = new EmployeeService();
            customers = customerService.GetCustomers();
            employees = employeeService.GetEmployees();
            LoadCmbData();
            if (order == null)
            {
                isEditMode = false;
                currentOrder = new Order();
                dpOrderDate.SelectedDate = DateTime.Today;
            }
            else
            {
                isEditMode = true;
                currentOrder = order;
                cmbCustomer.SelectedValue = order.CustomerId;
                cmbEmployee.SelectedValue = order.EmployeeId;
                dpOrderDate.SelectedDate = order.OrderDate;
            }

        }
        private void LoadCmbData()
        {
            cmbCustomer.ItemsSource = customers;
            cmbCustomer.DisplayMemberPath = "ContactName";
            cmbCustomer.SelectedValuePath = "CustomerId";
            cmbEmployee.ItemsSource = employees;
            cmbEmployee.DisplayMemberPath = "Name";
            cmbEmployee.SelectedValuePath = "EmployeeId";
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
            object? customerVal = cmbCustomer.SelectedValue;
            object? employeeVal = cmbEmployee.SelectedValue;
            DateTime? orderDate = dpOrderDate.SelectedDate;

            if (customerVal == null || employeeVal == null || orderDate == null)
            {
                MessageBox.Show("Please select a customer, employee and order date.",
                                "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int customerId = (int)customerVal;
            int employeeId = (int)employeeVal;
            currentOrder.CustomerId = customerId;
            currentOrder.EmployeeId = employeeId;
            currentOrder.OrderDate = orderDate.Value;

            bool result = isEditMode
                ? orderService.UpdateOrder(currentOrder)
                : orderService.AddOrder(currentOrder);

            if (result)
            {
                MessageBox.Show(isEditMode ? "Order updated successfully." : "Order added successfully.",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Failed to save order.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Order GetOrder() =>  currentOrder;
        
    }
}
