using HomeWork2.Models;
using HomeWork2.DTO;

namespace HomeWork2.Repository
{
    public interface ICartsRepository
    {
        Cart? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Substract(Guid productId, string userId);
        public void Clear(string userId);
    }
}
