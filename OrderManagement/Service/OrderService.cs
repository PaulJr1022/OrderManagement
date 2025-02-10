using OrderManagement.DTO.Request;
using OrderManagement.Entity;
using OrderManagement.IRepository;
using OrderManagement.IService;
using OrderManagement.Repository;

namespace OrderManagement.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //public async Task<IEnumerable<Order>> GetAllOrders()
        //{
        //    return await _orderRepository.GetAllOrders();
        //}

        //public async Task<Order> GetOrderById(int id)
        //{
        //    return await _orderRepository.GetOrderById(id);
        //}

        //public async Task AddOrder(OrderRequest order)
        //{
        //    var Order = new Order();

        //    //Order.Id = order.Id;
        //    Order.ProductId = order.ProductId;
        //    Order.OrderDate = order.OrderDate;
        //    Order.Quantity = order.Quantity;
        //    Order.TotalPrice = order.TotalPrice;
        //    Order.CustomerId = order.CustomerId;
        //    Order.Status = order.Status;

        //    var Orders = _orderRepository.AddOrder(Order);
        //}

        //public async Task UpdateOrder(OrderRequest order, int id)
        //{
        //    var Order = await _orderRepository.UpdateOrder(id);
        //    if (Order.Id == id)
        //    {
        //        //Order.ProductId = order.ProductId;
        //        Order.OrderDate = order.OrderDate;
        //        Order.Quantity = order.Quantity;
        //        Order.TotalPrice = order.TotalPrice;
        //        //Order.CustomerId = order.CustomerId;
        //        Order.Status = order.Status;
        //    }
        //}

        //public async Task DeleteOrder(int id)
        //{
        //    var Order = await _orderRepository.DeleteOrder(id);
        //    if (Order.Id == id)
        //    {
        //        await _orderRepository.DeleteOrder(id);
        //    }
        //}

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task AddOrder(OrderRequest orderRequest)
        {
            var order = new Order
            {
                ProductId = orderRequest.ProductId,
                OrderDate = orderRequest.OrderDate,
                Quantity = orderRequest.Quantity,
                TotalPrice = orderRequest.TotalPrice,
                CustomerId = orderRequest.CustomerId,
                Status = orderRequest.Status
            };

            await _orderRepository.AddOrder(order);
        }

        public async Task UpdateOrder(OrderRequest orderRequest, int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order != null)
            {
                order.OrderDate = orderRequest.OrderDate;
                order.Quantity = orderRequest.Quantity;
                order.TotalPrice = orderRequest.TotalPrice;
                order.Status = orderRequest.Status;

                await _orderRepository.UpdateOrder(order);
            }
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order != null)
            {
                await _orderRepository.DeleteOrder(id);
            }
        }

    }
}
