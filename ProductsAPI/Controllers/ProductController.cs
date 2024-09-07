using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Model;
using ProductsApplication.Inbound;
using ProductsDomain;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController(
        CreateProductUseCase createProductUseCase, 
        GetAllProductsUseCase getAllProductsUseCase,
        GetProductByIdUseCase getProductByIdUseCase
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

        [HttpGet(Name = "Get products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(getAllProductsUseCase.GetAllProducts());
        }

        [HttpGet("{productId}", Name = "Get product by id")]
        public ActionResult<Product> GetProductById(Guid productId)
        {
            Product? product = getProductByIdUseCase.GetProductById(new GetProductByIdUseCase.Query { ProductId = productId});
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
