using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Model;
using ProductsApplication.Inbound;
using ProductsDomain;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController(
        CreateProductUseCase createProductUseCase, 
        GetAllProductsUseCase getAllProductsUseCase) : ControllerBase
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
            var uri = Url.Action("Get product", new { id = product.Id });
            return Created(uri, product);
        }

        [HttpGet(Name = "Get Products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(getAllProductsUseCase.GetAllProducts());
        }
    }
}
