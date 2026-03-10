using HomeWork2.Models;
using HomeWork2.DTO;
using HomeWork2.DTO.Product;

namespace HomeWork2.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        public ProductResponseDto? TryGetById(Guid productId);
        void Add(string name, decimal cost, string description);
        void Update(Guid id, ProductDTO product);
        void Delete(Guid id);

    }
}
