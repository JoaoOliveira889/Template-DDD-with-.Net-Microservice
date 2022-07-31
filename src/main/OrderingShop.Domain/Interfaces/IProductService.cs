using OrderingShop.Domain.Dtos;

namespace OrderingShop.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(ProductDto product);
        Task<bool> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int id);
    }
}
