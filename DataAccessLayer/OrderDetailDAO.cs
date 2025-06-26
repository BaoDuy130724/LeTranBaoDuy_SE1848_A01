using BusinessObjects;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        public List<OrderDetail> GetDetailsByOrderId(int orderId)
        {
            using var context = new LucySalesDataContext();
            return context.OrderDetails
                          .Include(od => od.Product) 
                          .Where(od => od.OrderId == orderId)
                          .ToList();
        }
        public void AddOrderDetail(OrderDetail detail)
        {
            using var context = new LucySalesDataContext();
            context.OrderDetails.Add(detail);
            context.SaveChanges();
        }

        public void DeleteOrderDetailsByOrderId(int orderId)
        {
            using var context = new LucySalesDataContext();
            var details = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            context.OrderDetails.RemoveRange(details);
            context.SaveChanges();
        }

        public bool HasDetails(int orderId)
        {
            using var context = new LucySalesDataContext();
            return context.OrderDetails.Any(od => od.OrderId == orderId);
        }
    }
}
