using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static CustomerRepository? _instance;
        private static readonly object _lock = new();

        public static CustomerRepository Instance // lấy instance của CustomerRepository theo mô hình Singleton
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new CustomerRepository();
                    return _instance;
                }
            }
        }

        private readonly CustomerDAO _dao;

        private CustomerRepository()
        {
            _dao = new CustomerDAO();
        }

        public bool AddCustomer(Customer customer) => _dao.AddCustomer(customer);

        public bool DeleteCustomer(int id) => _dao.DeleteCustomer(id);

        public bool DeleteCustomer(Customer customer) => _dao.DeleteCustomer(customer);

        public Customer? GetCustomerById(int id) => _dao.GetCustomerById(id);

        public Customer? GetCustomerByPhone(string phone) => _dao.GetCustomerByPhone(phone);

        public List<Customer> GetCustomers() => _dao.GetCustomer();

        public bool UpdateCustomer(Customer customer) => _dao.UpdateCustomer(customer);

        public Customer? GetCustomerByName(string name) => _dao.GetCustomerByName(name);

    }
}
