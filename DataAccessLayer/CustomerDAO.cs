using BusinessObjects;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //View, add, edit, and delete customer information
    public class CustomerDAO
    {
          
        public  List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using var context = new LucySalesDataContext();
                customers = context.Customers.ToList();
            }catch(Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return customers;
        }
        public  Customer GetCustomerById(int id)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public Customer? GetCustomerByName(string name)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Customers.FirstOrDefault(c => c.CompanyName == name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public  Customer? GetCustomerByPhone(string phone)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Customers.FirstOrDefault(c => c.Phone == phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public bool AddCustomer(Customer customer)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Customers.Update(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public  bool DeleteCustomer(int id)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                context.Customers.Remove(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool DeleteCustomer(Customer customer)   
        {
            try
            {
                if(DeleteCustomer(customer.CustomerId)) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                
            }
            return false;
        }
    }
}

