using BusinessObjects;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportDAO
    {
        public List<Order> GetOrdersByDateRange(DateTime? startDate, DateTime? endDate)
        {
            using var context = new LucySalesDataContext();

            DateTime start = startDate ?? new DateTime(1753,1,1);
            DateTime end = endDate ?? DateTime.MaxValue;

            return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}
