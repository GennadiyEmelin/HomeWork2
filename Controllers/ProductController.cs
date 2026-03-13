using HomeWork2.Models;
using HomeWork2.DTO;
using HomeWork2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using HomeWork2.DTO.Product;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;

        public ProductController(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ProductResponseDto>> GetAll()
        {
            var products = _productsRepository.GetAll();
            return products;
        }
        [HttpGet("GetById")]
        public ProductResponseDto GetById(Guid id)
        {
            var product = _productsRepository.TryGetById(id);
            if (product == null)
            {
                return new ProductResponseDto();
            }
            return product;
        }
        [HttpPost("Add")]
        public ActionResult<string> Add(ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage))
                    .ToList();

                return BadRequest($"Ошибки: {string.Join(", ", errors)}");
            }

            if (_productsRepository.GetAll().Any(p => p.Name == product.Name))
            {
                return BadRequest($"Товар с именем '{product.Name}' уже есть");
            }
            try
            {
                _productsRepository.Add(product);
                return Ok($"Товар '{product.Name}' успешно добавлен!");
            }
            catch
            {
                return StatusCode(500, "Ошибка сервера при добавлении");
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(Guid id, ProductDTO product)
        {
            var prod = _productsRepository.TryGetById(id);
            if (prod == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage))
                    .ToList();

                return BadRequest($"Ошибки: {string.Join(", ", errors)}");
            }
            _productsRepository.Update(id, product);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            var product = _productsRepository.TryGetById(id);
            if (product == null)
            {
                return BadRequest();
            }
            _productsRepository.Delete(id);
            return Ok();

        }
    }
}