using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int orderId);
        Order GetOrderById(int orderId);
        List<Order> GetOrderByCustomerId(int customerId);
        List<Order> GetOrdersbyCustomerName(string customerName);
    }
}
