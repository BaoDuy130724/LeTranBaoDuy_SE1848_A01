using BusinessObjects;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        public Employee? GetEmployeeLogin(string Username, string password)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var logined = context.Employees.FirstOrDefault(e => e.UserName==Username && e.Password==password);
                if (logined != null) return logined;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }
        public List<Employee> GetEmployees()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Employee>();
            }
        }
    }
}
