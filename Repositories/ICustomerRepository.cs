using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer? GetCustomerById(int id);
        Customer? GetCustomerByPhone(string phone);
        Customer? GetCustomerByName(string name);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool DeleteCustomer(Customer customer);
    }
}
