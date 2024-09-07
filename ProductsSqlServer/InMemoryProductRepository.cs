﻿using ProductsApplication.Inbound;
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

        public Product? GetById(Guid productId)
        {
            return products.SingleOrDefault(product => product.Id == productId);
        }

        public void Update(Product product)
        {
            Product retrievedProduct = GetById(product.Id) ?? throw new ProductNotFoundException(product.Id);
            retrievedProduct.Price = product.Price;
            retrievedProduct.Name = product.Name;
        }
    }
}
