using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetDetailsByOrderId(int orderId);
        void DeleteOrderDetailsByOrderId(int orderId);
        void AddOrderDetail(OrderDetail detail);
        bool HasDetails(int orderId);
    }
}
