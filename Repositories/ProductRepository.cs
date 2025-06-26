using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static ProductRepository _instance;
        private static readonly object _lock = new();
        public static ProductRepository Instance
        {
            get
            {

                lock (_lock)
                {
                    return _instance ??= new ProductRepository();
                }

            }
        }
        private readonly ProductDAO _dao;
        private ProductRepository()
        {
            _dao = new ProductDAO();
        }
        public bool AddProduct(Product p) => _dao.AddProduct(p);

        public bool DeleteProduct(Product p) => _dao.DeleteProduct(p);
        
        public Product GetProductById(int product) => _dao.GetProductById(product);

        public List<Product> GetProducts() => _dao.GetProducts();

        public bool UpdateProduct(Product p) => _dao.UpdateProduct(p);

        public List<Product> GetProductByName(string name) => _dao.GetProductByName(name);

    }
}
