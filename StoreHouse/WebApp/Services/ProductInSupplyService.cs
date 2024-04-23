using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class ProductInSupplyService
    {
        private readonly ARepository<ProductInSupply> _productInSupplyRepo;
        private readonly ARepository<Product> _productRepository;
        private readonly ARepository<Sku> _skuRepository;

        private readonly SupplyService _supplyService;

        public ProductInSupplyService(
            ARepository<ProductInSupply> productInSupplyRepo,
            ARepository<Product> productRepository,
            ARepository<Sku> skuRepository,
            SupplyService supplyService)
        {
            _productInSupplyRepo = productInSupplyRepo;
            _productRepository = productRepository;
            _skuRepository = skuRepository;

            _supplyService = supplyService;
        }

        public SupplyEditViewModel GetSupplyEditViewModel(int supplyId)
        {
            SupplyViewModel supply = _supplyService.GetViewModelById(supplyId) 
                ?? throw new NullReferenceException();

            List<ProductInSupplyViewModel> productsInSupply = _productInSupplyRepo
                .ExecuteQuery(ProductInSupplyRepository.SelectBySupplyId(supplyId))
                .Select(entity => new ProductInSupplyViewModel(entity))
                .ToList();

            foreach (var item in productsInSupply)
            {
                Sku sku = _skuRepository
                    .ExecuteQuery(SkuRepository.SelectSKUBySKU(item.Sku))
                    .FirstOrDefault()
                    ?? throw new NullReferenceException();
                
                item.SetSkuData(sku);
                
                Product product = _productRepository
                    .ExecuteQuery(ProductRepository.SelectById(item.ProductId))
                    .FirstOrDefault()
                    ?? throw new NullReferenceException();

                item.SetProductData(product);
            }

            return new SupplyEditViewModel(supply, productsInSupply.ToList());
        }

        public void AddProductToSupply(ProductInSupplyEditVM product)
        {
            _skuRepository.Insert(new Sku(string.Empty, product.ProductId, product.ProductionDate, product.SaleK));

            Sku sku = _skuRepository
                .ExecuteQuery(
                    SkuRepository.SelectSKUByData(
                        product.ProductId, product.ProductionDate, product.SaleK))
                .FirstOrDefault()
                ?? throw new NullReferenceException();

            _productInSupplyRepo.Insert(new ProductInSupply(product.SupplyId, product.Amount, product.Price, sku.SKU, 0));
        }

        public void DeleteProductFromSupply(int productInSupplyId)
        {
            _productInSupplyRepo.Delete(new ProductInSupply(productInSupplyId));
        }
    }

    public class ProductInSupplyViewModel
    {
        private ProductInSupply _productInSupply;
        private Product _product;
        private Sku _sku;

        public int Id => _productInSupply.Id;

        public string Sku => _productInSupply.SKU;

        public int ProductId => _sku.ProductId;

        public string Name => _product.Name;

        public string Manufacturer => _product.Manufacturer;

        public DateTime ProductionDate => _sku.ProductionDate;

        public decimal SaleK => _sku.SaleK;

        public decimal Price => _productInSupply.Price;

        public int Amount => _productInSupply.Amount;

        public ProductInSupplyViewModel(ProductInSupply productInSupply)
        {
            _productInSupply = productInSupply;
        }

        public void SetProductData(Product product)
        {
            _product = product;
        }

        public void SetSkuData(Sku sku)
        {
            _sku = sku;
        }
    }

    public class ProductInSupplyEditVM
    {
        [HiddenInput]
        public int ProductId { get; set; }

        [HiddenInput]
        public int SupplyId { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public decimal SaleK { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        public ProductInSupplyEditVM()
        {

        }

        public ProductInSupplyEditVM(int productId)
        {
            ProductId = productId;
        }

        public ProductInSupplyEditVM(int productId, int supplyId)
        {
            ProductId = productId;
            SupplyId = supplyId;
        }
    }

    public class SupplyEditViewModel
    {
        public SupplyViewModel Supply { get; set; }

        public List<ProductInSupplyViewModel> Products { get; }

        public SupplyEditViewModel(SupplyViewModel supply, List<ProductInSupplyViewModel> products)
        {
            Supply = supply;
            Products = products;
        }
    }
}
