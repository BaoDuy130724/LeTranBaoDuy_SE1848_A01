using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetDetailsByOrderId(int orderId);
        void AddOrderDetail(OrderDetail detail);
        void DeleteOrderDetailsByOrderId(int orderId);
        bool HasDetails(int orderId);
    }
}
