using BusinessObjects;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //Create and manage orders, including order details, employee handling, and customer information
    public class OrderDAO
    {
        List<Order> orders = new List<Order>();
        public List<Order> GetOrders()
        {
            try
            {
                using var context = new LucySalesDataContext();
                orders = context.Orders
                    .Include(o => o.OrderDetails) // Include related OrderDetails
                    .Include(o => o.Employee) // Include related Employee
                    .Include(o => o.Customer) // Include related Customer
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return orders;
        } 
        public bool AddOrder(Order order)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Orders.Add(order);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the order: {ex.Message}");
                return false;
            }
        }
        public bool UpdateOrder(Order order)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Orders.Update(order);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the order: {ex.Message}");
                return false;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var order = context.Orders.Find(orderId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    return true;
                }
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the order: {ex.Message}");
                return false;
            }
        }
        public Order? GetOrderById(int orderId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Orders
                    .Include(o => o.OrderDetails)
                    .Include(o => o.Employee)
                    .Include(o => o.Customer)
                    .FirstOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the order: {ex.Message}");
                return null;
            }
        }
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(o => o.OrderDetails)
                    .Include(o => o.Employee)
                    .Include(o => o.Customer)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the order by customer ID: {ex.Message}");
                return null;
            }
        }
    }
}
