using OrderManagement.DTO.Request;
using OrderManagement.Entity;

namespace OrderManagement.IService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerRequest customerRequestDTO);
        Task UpdateCustomerAsync(CustomerRequest customerRequestDTO, int id);
        Task DeleteCustomerAsync(int id);
    }
}
