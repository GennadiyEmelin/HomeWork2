using HomeWork2.Models;
using HomeWork2.DTO;
using System.Web.Mvc;
using System.Xml.Linq;
using HomeWork2.Data;
using Microsoft.EntityFrameworkCore;
using HomeWork2.DTO.Product;
using HomeWork2.Mappers;
namespace HomeWork2.Repository
{
    public class ProductsRepository: IProductRepository
    {
        
        private readonly AppDbContext _appDbContext;
        public ProductsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Product> GetAll() => _appDbContext.Products.Where(p=>p.IsDelete == false).AsNoTracking().ToList();

        public ProductResponseDto? TryGetById(Guid productId)
        {
            var prod = _appDbContext.Products.AsNoTracking().FirstOrDefault(product => product.Id == productId && product.IsDelete == false);
            return ProductMapper.ToProductResponseDto(prod);
        }

        public void Add(string name, decimal cost, string description)
        {
            var product = new Product ( name, cost, description);

            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public void Update(Guid id, ProductDTO productDto)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return;

            product.Name = productDto.Name;
            product.Cost = productDto.Cost;
            product.Description = productDto.Description;
            _appDbContext.SaveChanges();
        }

        public void Delete(Guid id) 
        {
            var product = _appDbContext.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                return;
            product.IsDelete = true;
            _appDbContext.SaveChanges();
        }
    }
}
