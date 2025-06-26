using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int product);
        List<Product> GetProductByName(string name);
        bool AddProduct(Product p);
        bool UpdateProduct(Product p);
        bool DeleteProduct(Product p);
    }
}
