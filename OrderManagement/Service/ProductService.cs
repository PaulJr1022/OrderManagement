using OrderManagement.DTO.Request;
using OrderManagement.Entity;
using OrderManagement.IRepository;
using OrderManagement.IService;
using OrderManagement.Repository;

namespace OrderManagement.Service
{
    public class ProductService : IProductServicecs
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository product)
        {
            _productRepository = product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task AddProduct(ProductRequest productRequestDTO)
        {
            var product = new Product();

            product.Name = productRequestDTO.Name;
            product.Price = productRequestDTO.Price;
            product.Category = productRequestDTO.Category;
            product.Description = productRequestDTO.Description;
            product.stock = productRequestDTO.stock;
            product.CreatedAt = DateTime.UtcNow;

            var productData = _productRepository.AddProduct(product);
        }

        public async Task UpdateProductAsync(ProductRequest productRequestDTO, int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                product.Name = productRequestDTO.Name;
                product.Price = productRequestDTO.Price;
                product.Category = productRequestDTO.Category;
                product.Description = productRequestDTO.Description;
                product.stock = productRequestDTO.stock;
                product.CreatedAt = DateTime.UtcNow;

                await _productRepository.UpdateProduct(product);
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                await _productRepository.DeleteProduct(id);
            }
        }

        
    }
}
