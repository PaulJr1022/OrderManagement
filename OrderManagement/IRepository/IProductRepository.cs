using OrderManagement.Entity;

namespace OrderManagement.IRepository
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);


    }
}
