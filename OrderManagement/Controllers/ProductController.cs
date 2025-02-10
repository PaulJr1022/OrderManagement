using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DTO.Request;
using OrderManagement.IService;
using OrderManagement.Service;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServicecs _productService;

        public ProductController(IProductServicecs productServicecs)
        {
            _productService = productServicecs;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllProducts();
            if (product == null) return NotFound("NO data found...");

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound("Invalid Product id...");
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> Create(ProductRequest productRequestDTO)
        {
            await _productService.AddProduct(productRequestDTO);
            return Ok("Created succesfully...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequest productRequestDTO)
        {
            await _productService.UpdateProductAsync(productRequestDTO, id);
            return Ok("Updated Succesfully...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Deleted Successfully...");
        }



    }
}
