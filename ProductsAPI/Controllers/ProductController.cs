using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Model;
using ProductsApplication.Inbound;
using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController(
        CreateProductUseCase createProductUseCase, 
        GetAllProductsUseCase getAllProductsUseCase,
        GetProductByIdUseCase getProductByIdUseCase,
        UpdateProductUseCase updateProductUseCase,
        DeleteProductByIdUseCase deleteProductByIdUseCase
        ) : ControllerBase
    {

        [HttpPost(Name = "Create product")]
        public ActionResult<Product> Create(CreateProductRequestDto request)
        {
            CreateProductUseCase.Command command = new()
            {
                Name = request.Name,
                Price = request.Price,
            };

            Product product = createProductUseCase.CreateProduct(command);
            var uri = Url.Action("Get product by id", new { id = product.Id });
            return Created(uri, product);
        }

        [HttpPut("{productId}",Name = "Update product")]
        public ActionResult<Product> Update(Guid productId, UpdateProductRequestDto request)
        {
            UpdateProductUseCase.Command command = new()
            {
                Id = productId,
                Name = request.Name,
                Price = request.Price,
            };

            try
            {
                Product product = updateProductUseCase.UpdateProduct(command);
                return Ok(product);
            }
            catch (ProductNotFoundException productNotFoundException)
            {
                return NotFound(productNotFoundException.Message);
            };
        }

        [HttpGet(Name = "Get products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(getAllProductsUseCase.GetAllProducts());
        }

        [HttpGet("{productId}", Name = "Get product by id")]
        public ActionResult<Product> GetProductById(Guid productId)
        {
            try
            {
                Product product = getProductByIdUseCase.GetProductById(new GetProductByIdUseCase.Query { ProductId = productId });
                return Ok(product);
            }
            catch (ProductNotFoundException productNotFoundException)
            {
                return NotFound(productNotFoundException.Message);
            };
        }

        [HttpDelete("{productId}", Name = "Delete product by id")]
        public ActionResult DeleteProductById(Guid productId)
        {
            try
            {
                deleteProductByIdUseCase.DeleteProductById(new DeleteProductByIdUseCase.Command { ProductId = productId });
                return NoContent();
            }
            catch (ProductNotFoundException productNotFoundException)
            {
               return NotFound(productNotFoundException.Message);
            };
        }
    }
}
