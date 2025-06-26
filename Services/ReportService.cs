using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository ireportRepository;
        public ReportService()
        {
            ireportRepository = ReportRepository.Instance;
        }
        public List<Order> GetOrdersByDateRange(DateTime? startDate, DateTime? endDate)
        {
            return ireportRepository.GetOrderByDateRange(startDate, endDate);
        }
    }
}
