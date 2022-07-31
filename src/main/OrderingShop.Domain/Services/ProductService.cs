using AutoMapper;
using OrderingShop.Domain;
using OrderingShop.Domain.Dtos;
using OrderingShop.Domain.Interfaces;
using OrderingShop.Infrastructure.Context.Entities;
using OrderingShop.Infrastructure.Interfaces;

namespace OrderingShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<bool> CreateProductAsync(ProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);

            var result = await _productRepository.InsertAsync(productEntity);

            return result;
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            var productMap = _mapper.Map<Product>(product);

            var result = await _productRepository.UpdateAsync(productMap);

            return result;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return false;
            
            var result = await _productRepository.DeleteAsync(product);

            return result;
        }
    }
}

