using HomeWork2.Models;
using System.ComponentModel.DataAnnotations;

namespace HomeWork2.DTO
{
    public class OrderDTO
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Введите адрес!")]
        public string Address {  get; set; }
    }
}
