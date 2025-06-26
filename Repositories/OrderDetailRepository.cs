using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private static OrderDetailRepository? _instance;
        private static readonly object _lock = new object();
        public static OrderDetailRepository Instance 
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new OrderDetailRepository();
                    return _instance;
                }
            }

        }
        private readonly OrderDetailDAO _dao;
        private OrderDetailRepository()
        {
            _dao = new OrderDetailDAO();
        }

        public List<OrderDetail> GetDetailsByOrderId(int orderId) => _dao.GetDetailsByOrderId(orderId);

        public void AddOrderDetail(OrderDetail detail) => _dao.AddOrderDetail(detail);

        public void DeleteOrderDetailsByOrderId(int orderId) => _dao.DeleteOrderDetailsByOrderId(orderId);

        public bool HasDetails(int orderId) => _dao.HasDetails(orderId);

    }
}
