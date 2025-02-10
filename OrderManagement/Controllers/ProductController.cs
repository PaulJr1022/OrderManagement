using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DTO.Request;
using OrderManagement.IService;
using System.Threading.Tasks;
using System.Linq;
using OrderManagement.Service;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServicecs _productService;

        public ProductController(IProductServicecs productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            if (products == null || !products.Any())
                return NotFound("No data found...");

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound("Invalid product ID...");

            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> Create([FromBody] ProductRequest productRequestDTO)
        {
            if (productRequestDTO == null)
                return BadRequest("Invalid product data...");

            await _productService.AddProduct(productRequestDTO);
            return Ok("Product created successfully...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequest productRequestDTO)
        {
            if (productRequestDTO == null)
                return BadRequest("Invalid product data...");

            await _productService.UpdateProductAsync(productRequestDTO, id);
            return Ok("Product updated successfully...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Product deleted successfully...");
        }
    }
}
