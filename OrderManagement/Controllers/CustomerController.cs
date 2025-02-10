using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DTO.Request;
using OrderManagement.Entity;
using OrderManagement.IService;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        //[HttpGet("GetAllCustomer")]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        //{
        //    var customers = await _customerService.GetAllCustomersAsync();
        //    return Ok(customers);
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomerById(int id)
        //{
        //    var customer = await _customerService.GetCustomerByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound(new { message = "Customer not found" });
        //    }
        //    return Ok(customer);
        //}


        //[HttpPost("AddCustomer")]
        //public async Task<ActionResult> AddCustomer([FromBody] Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _customerService.AddCustomerAsync(customer);
        //    return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        //}


        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest(new { message = "Customer ID mismatch" });
        //    }

        //    try
        //    {
        //        await _customerService.UpdateCustomerAsync(customer);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound(new { message = "Customer not found" });
        //    }
        //}


        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteCustomer(int id)
        //{
        //    try
        //    {
        //        await _customerService.DeleteCustomerAsync(id);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound(new { message = "Customer not found" });
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exsitingCustomers = await _customerService.GetAllCustomersAsync();
            if (exsitingCustomers == null) return NotFound("NO data found...");

            return Ok(exsitingCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound("Invalid customer id...");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest customerRequestDTO)
        {
            await _customerService.AddCustomerAsync(customerRequestDTO);
            return Ok("Created succesfully...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequest customerRequestDTO)
        {
            await _customerService.UpdateCustomerAsync(customerRequestDTO, id);
            return Ok("Updated Succesfully...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok("Deleted Successfully...");
        }


    }
}
