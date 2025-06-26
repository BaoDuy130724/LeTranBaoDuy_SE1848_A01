using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static EmployeeRepository? _instance;
        private static readonly object _lock = new();
        public static EmployeeRepository Instance 
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new EmployeeRepository();
                    return _instance;
                }
            }
        }
        private EmployeeDAO _dao;
        private EmployeeRepository() 
        {
            _dao = new EmployeeDAO();
        }
        public Employee? GetEmployeeLogin(string Username, string Password)
        {
            return _dao.GetEmployeeLogin(Username, Password);
        }

        public List<Employee> GetEmployees()
        {
            return _dao.GetEmployees();
        }
    }
}
