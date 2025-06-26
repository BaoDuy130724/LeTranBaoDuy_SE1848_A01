using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository iOrderRepository;
        public OrderService()
        {
            iOrderRepository = OrderRepository.Instance;
        }
        public bool AddOrder(Order order)
        {
            return iOrderRepository.AddOrder(order);
        }

        public bool DeleteOrder(int orderId)
        {
            return iOrderRepository.DeleteOrder(orderId);
        }

        public List<Order> GetOrderByCustomerId(int customerId)
        {
            return iOrderRepository.GetOrderByCustomerId(customerId);
        }

        public Order GetOrderById(int orderId)
        {
            return iOrderRepository.GetOrderById(orderId);
        }

        public List<Order> GetOrders()
        {
            return iOrderRepository.GetOrders();
        }

        public bool UpdateOrder(Order order)
        {
           return iOrderRepository.UpdateOrder(order);
        }
    }
}
