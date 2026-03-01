using HomeWork2.Enums;

namespace HomeWork2.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Status Status { get; set; }
        public List<OrderItems> Items { get; set; } = new List<OrderItems>();

    }
}
