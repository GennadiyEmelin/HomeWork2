using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork2.Models
{
    public class OrderItems
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}
