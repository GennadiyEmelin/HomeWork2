namespace HomeWork2.DTO.Product
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
    }
}
