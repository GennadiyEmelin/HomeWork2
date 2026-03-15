using HomeWork2.Models;
using HomeWork2.DTO;
using HomeWork2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using HomeWork2.DTO.Product;
using HomeWork2.Mappers;

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
        public ActionResult<ProductResponseDto> GetById(Guid id)
        {
            try
            {
                var product = _productsRepository.TryGetById(id);
                return Ok(ProductMapper.ToProductResponseDto(product));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
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
            try
            {
                _productsRepository.Delete(id);
                return Ok($"Продукт {id} помечен как удаленный");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}