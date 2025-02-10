using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity;
using OrderManagement.IRepository;

namespace OrderManagement.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly orderDBContext _orderDBContext;

        public OrderRepository(orderDBContext orderDBContext)
        {
            _orderDBContext = orderDBContext;
        }

        public async Task AddOrder(Order order)
        {
            _orderDBContext.Orders.Add(order);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderDBContext.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderDBContext.Orders.ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _orderDBContext.Orders.Update(order);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _orderDBContext.Orders.FindAsync(id);
            if (order != null)
            {
                _orderDBContext.Orders.Remove(order);
                await _orderDBContext.SaveChangesAsync();
            }
        }


    }
}
