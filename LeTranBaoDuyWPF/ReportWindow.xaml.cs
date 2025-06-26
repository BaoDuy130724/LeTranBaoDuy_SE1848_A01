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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        ReportService reportservice;
        OrderService orderService;
        public ReportWindow()
        {
            InitializeComponent();
            reportservice = new ReportService();
            orderService = new OrderService();
            LoadOrders();
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

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = dpFrom.SelectedDate;
            DateTime? endDate = dpTo.SelectedDate;
            if(endDate!=null && endDate > DateTime.Now)
            {
                MessageBox.Show("To date cannot be in the future.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (startDate != null && endDate != null && startDate > endDate)
            {
                MessageBox.Show("From date must not be later than To date.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var orders = reportservice.GetOrdersByDateRange(startDate, endDate);
            dgOrderReport.ItemsSource = orders;
        }
        private void LoadOrders()
        {
            var orders = reportservice.GetOrdersByDateRange(null,null);
            dgOrderReport.ItemsSource = orders;
        }
    }
}
