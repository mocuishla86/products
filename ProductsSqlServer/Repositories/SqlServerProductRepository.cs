using ProductsApplication.Outbound;
using ProductsDomain;
using ProductsSqlServer.Context;
using ProductsSqlServer.Entities;

namespace ProductsSqlServer.Repositories
{
    public class SqlServerProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public void Insert(Product product)
        {
            ProductEntity entity = ToEntity(product);
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return dbContext.Products.Select(productEntity => ToDomain(productEntity)).ToList();
        }

        public Product GetById(Guid productId)
        {
            ProductEntity productEntity = dbContext.Products
                .SingleOrDefault(productEntity => productEntity.Id == productId)
                ?? throw new ProductNotFoundException(productId);

            return ToDomain(productEntity);
        }

        public void Update(Product product)
        {
            if(!dbContext.Products.Any(productEntity => productEntity.Id == product.Id))
            {
                throw new ProductNotFoundException(product.Id);
            }

            ProductEntity entity = ToEntity(product);
            dbContext.Products.Update(entity);
            dbContext.SaveChanges();
        }

        public void DeleteById(Guid productId)
        {
            ProductEntity productEntity = dbContext.Products
               .SingleOrDefault(productEntity => productEntity.Id == productId)
               ?? throw new ProductNotFoundException(productId);

            dbContext.Entry(productEntity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        private static ProductEntity ToEntity(Product product)
        {
            return new() { Id = product.Id, Name = product.Name, Price = product.Price };
        }

        private static Product ToDomain(ProductEntity productEntity)
        {
            return new() { Id = productEntity.Id, Name = productEntity.Name, Price = productEntity.Price };
        }
    }
}
