using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity;
using OrderManagement.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly orderDBContext _orderDbContext;

        public ProductRepository(orderDBContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task AddProduct(Product product)
        {
            await _orderDbContext.Products.AddAsync(product);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _orderDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _orderDbContext.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _orderDbContext.Products.FindAsync(product.Id);
            if (existingProduct != null)
            {
                _orderDbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await _orderDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _orderDbContext.Products.FindAsync(id);
            if (product != null)
            {
                _orderDbContext.Products.Remove(product);
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}
