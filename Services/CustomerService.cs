using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository iCustomerRepository;
        public CustomerService()
        {
            iCustomerRepository = CustomerRepository.Instance;
        }
        public bool AddCustomer(Customer customer) => iCustomerRepository.AddCustomer(customer);
        

        public bool DeleteCustomer(int id) => iCustomerRepository.DeleteCustomer(id);
        

        public bool DeleteCustomer(Customer customer) => iCustomerRepository.DeleteCustomer(customer);
        

        public Customer? GetCustomerById(int id) => iCustomerRepository.GetCustomerById(id);

        public Customer? GetCustomerByName(string name) => iCustomerRepository.GetCustomerByName(name);

        public Customer? GetCustomerByPhone(string phone) => iCustomerRepository.GetCustomerByPhone(phone);
        

        public List<Customer> GetCustomers() => iCustomerRepository.GetCustomers();
        

        public bool UpdateCustomer(Customer customer) => iCustomerRepository.UpdateCustomer(customer);
        
    }
}
