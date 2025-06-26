using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReportService
    {
        List<Order> GetOrdersByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
