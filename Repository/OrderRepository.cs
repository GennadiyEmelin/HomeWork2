using HomeWork2.DTO;
using HomeWork2.Models;

namespace HomeWork2.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly List<Order> _orders = [];
        private readonly ICartsRepository _cartsRepository;
        public OrderRepository(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public void Add(OrderDTO order)
        {
            var cart = _cartsRepository.TryGetByUserId(order.UserId);
            if (cart == null) 
            {
                return;
            }
            var orders = new Order
            {
                Id = Guid.NewGuid(),
                UserId = order.UserId,
                Address = order.Address,
                Status = Enums.Status.Create,
                Items = cart.Items.Select(a => new OrderItems
                {
                    Id = Guid.NewGuid(),
                    ProductId = a.Product.Id,
                    ProductName = a.Product.Name,
                    Cost = a.Product.Cost
                }).ToList()
            };
            _orders.Add(orders);
            _cartsRepository.Clear(order.UserId);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public List<Order> GetByID(string userId)
        {
            var or = _orders.Where(i => i.UserId == userId).ToList();
            return or;
        }

        public void Delete(string userId)
        {
            var or = _orders.FirstOrDefault(i => i.UserId == userId);
            if (or == null)
                return;
            or.Status = Enums.Status.Delete;
        }

        public void Update(OrderDTO dto)
        {
            var order = _orders.FirstOrDefault(o => o.UserId == dto.UserId);

            if (order == null)
                return;

            order.Address = dto.Address;
        }
    }
}
