using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReportRepository : IReportRepository
    {
        private static ReportRepository? _instance;
        private static readonly object _lock = new object(); 
        public static ReportRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ReportRepository();
                        }
                    }
                }
                return _instance;
            }
        }
        private ReportDAO _dao;
        private ReportRepository()
        {
            _dao = new ReportDAO();
        }

        public List<Order> GetOrderByDateRange(DateTime? startDate, DateTime? endDate) => _dao.GetOrdersByDateRange(startDate, endDate);
        
    }
}
