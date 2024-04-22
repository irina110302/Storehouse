using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class ProductService
    {
        private ARepository<Product> _productRepository;

        public ProductService(ARepository<Product> productRepository) 
        {
            _productRepository = productRepository;
        }

        public List<ProductViewModel> GetViewModels()
        {
            return _productRepository
                .ExecuteQuery(ProductRepository.SelectAllQuery)
                .Select(product => new ProductViewModel(product))
                .ToList();
        }

        public void AddProduct(ProductEditViewModel newProduct)
        {
            _productRepository.Insert(newProduct.ProductEntity);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(new Product(id));
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string ColorName { get; set; }

        public ProductViewModel(Product product)
        {
            Id = product.Id; 
            Name = product.Name; 
            Manufacturer = product.Manufacturer;
            ColorName = product.Color?.Name ?? "none";
        }
    }

    public class ProductEditViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public Product ProductEntity => new(0, Name, Manufacturer);
    }
}
