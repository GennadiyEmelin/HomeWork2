using HomeWork2.Models;
using HomeWork2.DTO;

namespace HomeWork2.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        public Product? TryGetById(Guid productId);
        void Add(string name, decimal cost, string description);

    }
}
