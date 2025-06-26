using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iproductRepository;
        public ProductService()
        {
            iproductRepository = ProductRepository.Instance;
        }
        public bool AddProduct(Product p)
        {
            return iproductRepository.AddProduct(p);
        }

        public bool DeleteProduct(Product p)
        {
            return iproductRepository.DeleteProduct(p);
        }

        public Product GetProductById(int productID)
        {
            return iproductRepository.GetProductById(productID);
        }

        public List<Product> GetProductByName(string name) => iproductRepository.GetProductByName(name);

        public List<Product> GetProducts()
        {
            return iproductRepository.GetProducts();    
        }

        public bool UpdateProduct(Product p)
        {
            return iproductRepository.UpdateProduct(p);
        }
    }
}
