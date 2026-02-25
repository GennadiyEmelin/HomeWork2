using HomeWork2.Enums;

namespace HomeWork2.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public List<OrderItems> Items { get; set; }

    }
}
