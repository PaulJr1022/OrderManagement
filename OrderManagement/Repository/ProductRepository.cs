using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity;
using OrderManagement.IRepository;

namespace OrderManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly orderDBContext _orderDBContext;
        public ProductRepository(orderDBContext orderDBContext) 
        {
            _orderDBContext = orderDBContext;
        }


        public async Task AddProduct(Product product)
        {
            _orderDBContext.Products.Add(product);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _orderDBContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _orderDBContext.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _orderDBContext.Products.Update(product);
            await _orderDBContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _orderDBContext.Products.FindAsync(id);
            if (product != null)
            {
                _orderDBContext.Products.Remove(product);
                await _orderDBContext.SaveChangesAsync();
            }
        }

    }
}
