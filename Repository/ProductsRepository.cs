using HomeWork2.Models;
using HomeWork2.DTO;
using System.Web.Mvc;
using System.Xml.Linq;
namespace HomeWork2.Repository
{
    public class ProductsRepository: IProductRepository
    {
        private int _instanceCounter = 0;

        private readonly List<Product> _products;

        public ProductsRepository()
        {
            _products =
            [
               new Product ("Товар 1", 129.99m, "Описание 1"),
               new Product ("Товар 2", 129.99m, "Описание 2"),
               new Product ("Товар 3", 129.99m, "Описание 3"),
               new Product ("Товар 4", 129.99m, "Описание 4"),
               new Product ("Товар 5", 129.99m, "Описание 5"),
            ];
        }

        public List<Product> GetAll() => _products;

        public Product? TryGetById(Guid productId)
        {
            return _products.FirstOrDefault(product => product.Id == productId);
        }

        public void Add(string name, decimal cost, string description)
        {
            var product = new Product ( name, cost, description);

            _products.Add(product);
        }

        public void Update(Guid id, ProductDTO productDto)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return;

            product.Name = productDto.Name;
            product.Cost = productDto.Cost;
            product.Description = productDto.Description;
        }

        public void Delete(Guid id) 
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                return;
            product.IsDelete = true;
        }
    }
}
