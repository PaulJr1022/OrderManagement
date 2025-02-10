using OrderManagement.DTO.Request;
using OrderManagement.Entity;

namespace OrderManagement.IService
{
    public interface IProductServicecs
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(ProductRequest productRequestDTO);
        Task UpdateProductAsync(ProductRequest productRequestDTO, int id);
        Task DeleteProduct(int id);
    }
}
