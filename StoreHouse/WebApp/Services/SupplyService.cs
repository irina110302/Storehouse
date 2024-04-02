using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class SupplyService
    {
        private readonly ARepository<Supply> _supplyRepository;
        private readonly ARepository<ProductInSupply> _productInSupplyRepo;

        public SupplyService(
            ARepository<Supply> supplyRepository, 
            ARepository<ProductInSupply> productInSupplyRepo) 
        { 
            _supplyRepository = supplyRepository;
            _productInSupplyRepo = productInSupplyRepo;
        }
    }

    public class SupplyViewModel
    {
        public int Id { get; set; }

        public int StorehouseId { get; set; }

        public int SupplierId { get; set; }

        public DateTime DateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public SupplyViewModel(Supply supply)
        {
            Id = supply.Id;
            StorehouseId = supply.StorehouseId;
            SupplierId = supply.SupplierId;
            DateTime = supply.DateTime;
            TotalPrice = supply.TotalPrice;
        }
    }

    public class SupplyEditViewModel
    {

    }
}
