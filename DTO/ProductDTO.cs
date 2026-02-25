using System.ComponentModel.DataAnnotations;

namespace HomeWork2.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Укажите название товара")]
        [MinLength(3, ErrorMessage = "Название должно быть не короче 3 букв")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        [Range(1, 1000000, ErrorMessage = "Цена должна быть от 1 до 1 000 000")]
        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public ProductDTO()
        {

        }
    }
}
