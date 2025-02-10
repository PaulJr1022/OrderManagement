using OrderManagement.IRepository;

namespace OrderManagement.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;

        public OrderRepository(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
