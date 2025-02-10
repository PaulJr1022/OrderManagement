using OrderManagement.Entity;

namespace OrderManagement.IRepository
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }
}
