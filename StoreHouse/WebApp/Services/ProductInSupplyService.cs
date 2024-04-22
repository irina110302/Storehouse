using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class ProductInSupplyService
    {
        private readonly ARepository<Supply> _supplyRepository;
        private readonly ARepository<ProductInSupply> _productInSupplyRepo;
        private readonly ARepository<Product> _productRepository;
        private readonly ARepository<Sku> _skuRepository;

        public ProductInSupplyService(
            ARepository<Supply> supplyRepository,
            ARepository<ProductInSupply> productInSupplyRepo,
            ARepository<Product> productRepository,
            ARepository<Sku> skuRepository)
        {
            _supplyRepository = supplyRepository;
            _productInSupplyRepo = productInSupplyRepo;
            _productRepository = productRepository;
            _skuRepository = skuRepository;
        }

        //public SupplyEditViewModel GetSupplyEditViewModel(int supplyId)
        //{
        //    Supply supply = _supplyRepository
        //        .ExecuteQuery(SupplyRepository.SelectById(supplyId))
        //        .First();

        //    //List<Sku> skus = _skuRepository.ExecuteQuery(SkuRepository.)
        //    return new SupplyEditViewModel();
        //}
    }

    public class ProductInSupplyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public DateTime ProductionDate { get; set; }

        public decimal SaleK { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public ProductInSupplyViewModel(ProductInSupply productInSupply, Product product, Sku sku)
        {
            Name = product.Name;
            Manufacturer = product.Manufacturer;

            ProductionDate = sku.ProductionDate;
            SaleK = sku.SaleK;

            Id = productInSupply.Id;
            Price = productInSupply.Price;
            Amount = productInSupply.Amount;
        }
    }

    public class ProductInSupplyAddVM
    {
        public int SkuId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }

    public class SupplyEditViewModel
    {
        public int Id { get; set; }

        public List<Sku> AvailableSkus { get; }

        public List<ProductInSupplyViewModel> Products { get; }

        public SupplyEditViewModel(Supply supply, List<ProductInSupplyViewModel> products, List<Sku> availableSkus)
        {
            Id = supply.Id;
            Products = products;
            AvailableSkus = availableSkus;
        }
    }
}
