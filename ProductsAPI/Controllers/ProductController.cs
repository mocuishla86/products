using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Model;
using ProductsApplication.Inbound;
using ProductsDomain;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        [HttpPost(Name = "Create product")]
        public ActionResult<Product> Create(CreateProductRequestDto request)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
            };
            var uri = Url.Action("Get product", new { id = product.Id });
            return Created(uri, product);
        }
    }
}
