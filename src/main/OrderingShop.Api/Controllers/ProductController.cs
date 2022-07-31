using Microsoft.AspNetCore.Mvc;
using OrderingShop.Domain.Dtos;
using OrderingShop.Domain.Interfaces;

namespace OrderingShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger
            , IProductService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var result = await _service.GetAllProductsAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Products not found");
            return NotFound("Products not found");
        }

        [HttpGet("GetProductById/{id:int}")]
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var result = await _service.GetProductByIdAsync(id);

            if (result is not null) return Ok(result);

            _logger.LogInformation("Product with id {Id} not found", id);
            return NotFound($"Product with {id} not found");
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.CreateProductAsync(product);

            if (result) return Ok("Product created with success");
            
            _logger.LogInformation("Product not created");
            return BadRequest("Error creating product");
        }

        [HttpPut("UpdateProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.UpdateProductAsync(product);
            
            if (result) return Ok("Product update with success");

            _logger.LogInformation("Product not update");
            return BadRequest("Error update product");
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            var result = await _service.DeleteProductAsync(id);

            if (result) return Ok($"Product with {id} deleted with success");

            _logger.LogInformation("Product with {Id} not remove", id);
            return BadRequest($"Product with {id} not remove");
        }
    }
}