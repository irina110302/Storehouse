using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class SupplyService
    {
        private readonly ARepository<Supply> _supplyRepository;
        private readonly ARepository<Storehouse> _storehouseRepository;
        private readonly ARepository<Supplier> _supplierRepository;

        public SupplyService(
            ARepository<Supply> supplyRepository, 
            ARepository<Supplier> supplierRepository,
            ARepository<Storehouse> storehouseRepository)
        {
            _supplyRepository = supplyRepository;
            _supplierRepository = supplierRepository;
            _storehouseRepository = storehouseRepository;
        }

        public List<SupplyViewModel> GetViewModels()
        {
            IEnumerable<Supplier> suppliers = _supplierRepository.ExecuteQuery(SupplierRepository.SelectAllQuery);
            IEnumerable<Storehouse> storehouses = _storehouseRepository.ExecuteQuery(StorehouseRepository.SelectAllQuery);   

            return _supplyRepository
                .ExecuteQuery(SupplyRepository.SelectAllQuery)
                .Select(entity => 
                    new SupplyViewModel(
                        entity, 
                        storehouses.FirstOrDefault(supplier => supplier.Id == entity.SupplierId),
                        suppliers.FirstOrDefault(supplier => supplier.Id == entity.SupplierId)
                        )
                    )
                .ToList();
        }

        public SupplyViewModel? GetViewModelById(int supplyId)
        {
            return GetViewModels().FirstOrDefault(supply => supply.Id == supplyId);
        }

        public void CreateSupply(int supplierId, int storehouseId) 
        {
            _supplyRepository.Insert(new Supply(supplierId, storehouseId));
        }

        public void RemoveSupply(int supplyId)
        {
            _supplyRepository.Delete(new Supply(supplyId));
        }
    }

    public class SupplyViewModel
    {
        public int Id { get; set; }

        public int StorehouseId { get; set; }

        public int SupplierId { get; set; }

        public string StorehouseAddress { get; set; }

        public string SupplierName { get; set; }

        public DateTime DateTime { get; set; }

        
        public SupplyViewModel(Supply supply, Storehouse storehouse, Supplier supplier)
        {
            Id = supply.Id;
            StorehouseId = supply.StorehouseId;
            SupplierId = supply.SupplierId;
            DateTime = supply.DateTime;
            StorehouseAddress = storehouse.Address;
            SupplierName = supplier.Name;
        }
    }
}
