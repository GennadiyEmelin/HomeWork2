using HomeWork2.DTO.Product;
using HomeWork2.Models;

namespace HomeWork2.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDto? ToProductResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
        }
    }
}
