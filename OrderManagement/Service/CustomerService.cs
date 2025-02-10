using OrderManagement.DTO.Request;
using OrderManagement.Entity;
using OrderManagement.IRepository;
using OrderManagement.IService;

namespace OrderManagement.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //    {
        //        return await _customerRepository.GetAllCustomersAsync();
        //    }

        //    public async Task<Customer> GetCustomerByIdAsync(int id)
        //    {
        //        return await _customerRepository.GetCustomerByIdAsync(id);
        //    }

        //    public async Task AddCustomerAsync(Customer customer)
        //    {
        //        if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email))
        //            throw new ArgumentException("Customer name and email are required.");

        //        await _customerRepository.AddCustomerAsync(customer);
        //    }

        //    public async Task UpdateCustomerAsync(Customer customer)
        //    {
        //        var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.Id);
        //        if (existingCustomer == null)
        //            throw new KeyNotFoundException("Customer not found.");

        //        existingCustomer.Name = customer.Name;
        //        existingCustomer.Email = customer.Email;
        //        existingCustomer.Phone = customer.Phone;
        //        existingCustomer.Address = customer.Address;

        //        await _customerRepository.UpdateCustomerAsync(existingCustomer);
        //    }

        //    public async Task DeleteCustomerAsync(int id)
        //    {
        //        var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
        //        if (existingCustomer == null)
        //            throw new KeyNotFoundException("Customer not found.");

        //        await _customerRepository.DeleteCustomerAsync(id);
        //    }
        //}



            public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
            {
               return await _customerRepository.GetAllCustomersAsync();
            }

            public async Task<Customer> GetCustomerByIdAsync(int id)
            {
                return await _customerRepository.GetCustomerByIdAsync(id);
            }

            public async Task AddCustomerAsync(CustomerRequest customerRequestDTO)
            {
                var customer = new Customer();
         
                customer.Name = customerRequestDTO.Name;
                customer.Email = customerRequestDTO.Email;
                customer.Phone = customerRequestDTO.Phone;
                customer.Address = customerRequestDTO.Address;
                customer.CreatedAt = DateTime.UtcNow;

                var customerData = _customerRepository.AddCustomerAsync(customer);
            }

            public async Task UpdateCustomerAsync(CustomerRequest customerRequestDTO, int id)
            {
                var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
                if (existingCustomer.Id == id)
                {
                    existingCustomer.Name = customerRequestDTO.Name;
                    existingCustomer.Email = customerRequestDTO.Email;
                    existingCustomer.Address = customerRequestDTO.Address;
                    existingCustomer.Phone = customerRequestDTO.Phone;
                }
            }

            public async Task DeleteCustomerAsync(int id)
            {
                var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
                if (existingCustomer.Id == id)
                {
                    await _customerRepository.DeleteCustomerAsync(id);
                }
            }
        }
    }

