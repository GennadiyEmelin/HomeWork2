using HomeWork2.Models;
using HomeWork2.DTO;
using HomeWork2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeWork2.Constant;
using System.Reflection.Metadata;

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;
        private readonly ICartsRepository _cartsRepository;

        public CartController(IProductRepository productsRepository, ICartsRepository cartsRepository)
        {
            _productsRepository = productsRepository;
            _cartsRepository = cartsRepository;
        }

        [HttpGet("GetCartById")]
        public ActionResult<Cart> Get()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            return cart;

        }

        [HttpPost("AddToCart")]
        public ActionResult<string> Add(Guid productId)
        {
            var productDto = _productsRepository.TryGetById(productId);

            if (productDto != null)
            {
                var product = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Cost = productDto.Cost,
                    Description = productDto.Description
                };

                _cartsRepository.Add(product, Constants.UserId);
            }
            return "Продукт добавлен";
        }

        [HttpPost("Subsract")]
        public ActionResult<string> Substact(Guid productId)
        {
            _cartsRepository.Substract(productId, Constants.UserId);
            return "Ok";
        }
    }
}
