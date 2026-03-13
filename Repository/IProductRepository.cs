using HomeWork2.Models;
using HomeWork2.DTO;
using HomeWork2.DTO.Product;

namespace HomeWork2.Repository
{
    public interface IProductRepository
    {
        List<ProductResponseDto?> GetAll();
        public ProductResponseDto? TryGetById(Guid productId);
        void Add(ProductDTO productDto);
        void Update(Guid id, ProductDTO product);
        void Delete(Guid id);

    }
}
