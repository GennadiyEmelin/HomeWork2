using System.ComponentModel.DataAnnotations;

namespace HomeWork2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public Product(string name, decimal cost, string description)
        {
            Name = name;
            Cost = cost;
            Description = description;
        }
        public Product()
        {
            
        }
    }
}
