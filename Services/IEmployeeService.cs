using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeService
    {
        Employee? GetEmployeeLogin(string username, string password);
        List<Employee> GetEmployees();
          
    }
}
