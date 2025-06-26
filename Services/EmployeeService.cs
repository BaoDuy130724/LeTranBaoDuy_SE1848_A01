using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository iemployeeRepository;
        public EmployeeService()
        {
            iemployeeRepository = EmployeeRepository.Instance;
        }
        public Employee? GetEmployeeLogin(string username, string password)
        {
            return iemployeeRepository.GetEmployeeLogin(username, password);   
        }
    }
}
