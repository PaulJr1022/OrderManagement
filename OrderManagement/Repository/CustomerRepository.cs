using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity;
using OrderManagement.IRepository;

namespace OrderManagement.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly orderDBContext _orderDBContext;

        public CustomerRepository(orderDBContext orderDBContext)
        {
            _orderDBContext = orderDBContext;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _orderDBContext.Customers.Add(customer);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _orderDBContext.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _orderDBContext.Customers.ToListAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _orderDBContext.Customers.Update(customer);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _orderDBContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _orderDBContext.Customers.Remove(customer);
                await _orderDBContext.SaveChangesAsync();
            }
        }


    }
}
