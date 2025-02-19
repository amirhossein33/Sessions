using Domain.Entity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.UI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> _products = [];


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);
        }


        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name))
                return BadRequest("Product data is invalid.");

            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }
    }

}
