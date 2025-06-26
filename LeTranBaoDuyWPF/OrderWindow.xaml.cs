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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        OrderService orderservice;
        OrderDetailService orderDetailService;
        private List<Order> orders;
        private List<OrderDetail> ordersDetail; 
        public OrderWindow()
        {
            InitializeComponent();
            orderservice = new OrderService();
            orders = new List<Order>();
            ordersDetail = new List<OrderDetail>();
            orderDetailService = new OrderDetailService();
            LoadData();
        }

        private void LoadData()
        {
            orders = orderservice.GetOrders();
            dgOrders.ItemsSource = orders;
            dgOrderDetail.ItemsSource = null;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtsearch.Text.Trim().ToLower();
            if(string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                orders = orderservice.GetOrdersbyCustomerName(keyword);
                dgOrders.ItemsSource = orders;
                dgOrderDetail.ItemsSource = null;
            }
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = dgOrders.SelectedItem as Order;
            if (selectedOrder == null)
            {
                dgOrderDetail.ItemsSource = null;
                return;
            }
            ordersDetail = orderDetailService.GetDetailsByOrderId(selectedOrder.OrderId); //Loi
            dgOrderDetail.ItemsSource = ordersDetail;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addOrderWindow = new OrderEditWindow();
            if(addOrderWindow.ShowDialog() == true)
            {
                orderservice.AddOrder(addOrderWindow.GetOrder());
                LoadData();
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var order = dgOrders.SelectedItem as Order;
            if(order == null)
            {
                MessageBox.Show("Please select an order to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(orderDetailService.HasDetails(order.OrderId))
            {
                MessageBox.Show("Cannot delete order with existing details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var ret = MessageBox.Show($"Are you sure you want to delete order {order.OrderId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                if (orderservice.DeleteOrder(order.OrderId))
                {
                    MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to delete order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var order = dgOrders.SelectedItem as Order;
            if(order == null)
            {
                MessageBox.Show("Please select an order to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var editOrderWindow = new OrderEditWindow(order);
            if (editOrderWindow.ShowDialog() == true)
            {
                orderservice.UpdateOrder(editOrderWindow.GetOrder());
                LoadData();
            }
        }
    }
}
