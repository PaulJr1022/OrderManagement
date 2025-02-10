using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DTO.Request;
using OrderManagement.IService;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            var existingOrders = await _orderService.GetAllOrders();
            if (existingOrders == null || !existingOrders.Any())
                return NotFound("No orders found...");

            return Ok(existingOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null) return NotFound("Invalid order ID...");

            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            await _orderService.AddOrder(orderRequest);
            return Ok("Order created successfully...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderRequest orderRequest)
        {
            await _orderService.UpdateOrder(orderRequest, id);
            return Ok("Order updated successfully...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return Ok("Order deleted successfully...");
        }
    }
}
