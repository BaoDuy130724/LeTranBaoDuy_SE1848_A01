using BusinessObjects;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    // Manage product information, including stock and prices
    public class ProductDAO
    {

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using var context = new LucySalesDataContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
            }
            return products;
        }
        public Product? GetProductById(int productID)
        {
            Product product = null;
            try
            {
                using var context = new LucySalesDataContext();
                product = context.Products.FirstOrDefault(p => p.ProductId == productID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product by ID: {ex.Message}");
                return null;
            }
            return product;
        }
        public List<Product> GetProductByName(string name)
        {
            List<Product> products = null;
            try
            {
                using var context = new LucySalesDataContext();
                products = context.Products.Where(p=>p.ProductName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product by name: {ex.Message}");
                return null;
            }
            return products;
        }
        public bool AddProduct(Product p)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }
        public bool UpdateProduct(Product p)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Products.Update(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }
        public bool DeleteProduct(Product p)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var product = context.Products.FirstOrDefault(x => x.ProductId == p.ProductId);
                product.Discontinued = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }
    }
}
