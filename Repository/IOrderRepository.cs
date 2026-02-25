using HomeWork2.DTO;
using HomeWork2.Models;

namespace HomeWork2.Repository
{
    public interface IOrderRepository
    {
        void Add(OrderDTO order);
        List<Order> GetAll();
        List<Order> GetByID(string userId);
        void Delete(string UdserId);
        void Update(OrderDTO order);
    }
}
