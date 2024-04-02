using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class SupplierService
    {
        private readonly ARepository<Supplier> _supplierRepository;

        public SupplierService(ARepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public List<SupplierViewModel> GetSupplierViewModels()
        {
            return _supplierRepository
                .ExecuteQuery(SupplierRepository.SelectAllQuery)
                .Select(entity => new SupplierViewModel(entity))
                .ToList();
        }
    }

    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public SupplierViewModel(Supplier supplier)
        {
            Id = supplier.Id;
            Name = supplier.Name;
            Address = supplier.Address;
            Phone = supplier.Phone;
            Email = supplier.Email;
        }
    }
}
