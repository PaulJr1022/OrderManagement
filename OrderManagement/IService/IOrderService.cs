using OrderManagement.DTO.Request;
using OrderManagement.Entity;

namespace OrderManagement.IService
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task AddOrder(OrderRequest orderRequest);
        Task UpdateOrder(OrderRequest orderRequest, int id);
        Task DeleteOrder(int id);
    }
}
