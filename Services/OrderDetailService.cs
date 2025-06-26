using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService()
        {
            _orderDetailRepository = OrderDetailRepository.Instance;
        }
        public void AddOrderDetail(OrderDetail detail) => _orderDetailRepository.AddOrderDetail(detail);

        public void DeleteOrderDetailsByOrderId(int orderId) => _orderDetailRepository.DeleteOrderDetailsByOrderId(orderId);

        public List<OrderDetail> GetDetailsByOrderId(int orderId) => _orderDetailRepository.GetDetailsByOrderId(orderId);

        public bool HasDetails(int orderId) => _orderDetailRepository.HasDetails(orderId);

    }
}
