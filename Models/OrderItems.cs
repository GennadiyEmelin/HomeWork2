namespace HomeWork2.Models
{
    public class OrderItems
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
    }
}
