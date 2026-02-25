using HomeWork2.DTO;
using HomeWork2.Models;
using HomeWork2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Web.Helpers;

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IOrderRepository _ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrderRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult Get() 
        {
            _ordersRepository.GetAll();
            return Ok();
        }

        [HttpPost("CreateFromCart")]
        public IActionResult Add(OrderDTO dto) 
        {
            if (!ModelState.IsValid) 
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage))
                    .ToList();
                return BadRequest($"Ошибки: {string.Join(", ", errors)}");
            }
            try
            { 
                _ordersRepository.Add(dto);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Ошибка сервера при добавлении");
            }
        }

        [HttpGet("GetOrderById")]
        public ActionResult<List<Order>> GetById(string UserId)
        {
            var order = _ordersRepository.GetByID(UserId);
            return order;
        }

        [HttpPost("DeleteOrder")]
        public IActionResult Delete(string userId)
        {
            if (_ordersRepository.GetByID(userId) == null)
            {
                return BadRequest();
            }
            else
            {
                _ordersRepository.Delete(userId);
            }
            return Ok();
        }

        [HttpPut("UpdateOrder")]
        public IActionResult Update(OrderDTO dto)
        {
            _ordersRepository.Update(dto);
            return Ok();
        }
    }
}
