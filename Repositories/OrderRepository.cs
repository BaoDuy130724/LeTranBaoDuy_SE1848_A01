using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static OrderRepository _instance; // Tạo biến tĩnh để lưu trữ instance duy nhất của OrderRepository
        private static readonly object _lock = new(); // một cái khóa tránh việc tạo nhiều instance cùng lúc = new ....()
        public static OrderRepository Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new OrderRepository(); // Lấy instance nếu đã tồn tại, nếu chưa thì tạo mới
                }
            }
        }
        private readonly OrderDAO _dao;
        private OrderRepository() // Constructor riêng tư để ngăn chặn việc tạo instance bên ngoài lớp này
        {
            _dao = new OrderDAO();
        }

        public bool AddOrder(Order order) => _dao.AddOrder(order);


        public bool DeleteOrder(int orderId) => _dao.DeleteOrder(orderId);
        

        public Order GetOrderById(int orderId) => _dao.GetOrderById(orderId);


        public List<Order> GetOrders() => _dao.GetOrders();


        public bool UpdateOrder(Order order) => _dao.UpdateOrder(order);

        public List<Order> GetOrderByCustomerId(int customerId) => _dao.GetOrderByCustomerId(customerId);

        public List<Order> GetOrdersByCustomerName(string customerName) => _dao.GetOrdersbyCustomerName(customerName);

    }
}
