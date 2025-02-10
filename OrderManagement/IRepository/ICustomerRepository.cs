using OrderManagement.Entity;
using OrderManagement.Service;

namespace OrderManagement.IRepository
{
    public interface ICustomerRepository 
    {
        Task AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
