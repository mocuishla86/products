using ProductsApplication.Outbound;
using ProductsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSqlServer
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> products = new();
        public void Insert(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
