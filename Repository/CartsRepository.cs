using HomeWork2.Models;
namespace HomeWork2.Repository
{
    public class CartsRepository: ICartsRepository
    {
        private readonly List<Cart> _carts = [];

        public Cart? TryGetByUserId(string userId)
        {
            return _carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                existingCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>()
            {
                new CartItem()
                {
                    Id = Guid.NewGuid(),
                    Product = product,
                    Quantity = 1
                }
            }
                };
                _carts.Add(existingCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item =>
                    item.Product.Id == product.Id);

                if (existingCartItem == null)
                {
                    var newCartItem = new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantity = 1
                    };
                    existingCart.Items.Add(newCartItem);
                }
                else
                {
                    existingCartItem.Quantity++;
                }
            }
        }

        public void Substract(Guid productId, string userId)
        {
            var cart = TryGetByUserId(userId);

            var cartItem = cart?.Items.FirstOrDefault(item => item.Product.Id == productId);

            if (cartItem == null)
            {
                return;
            }

            cartItem.Quantity--;

            if (cartItem.Quantity == 0)
            {
                cart?.Items.Remove(cartItem);
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart != null)
            {
                _carts.Remove(existingCart);
            }
        }
    }
}
