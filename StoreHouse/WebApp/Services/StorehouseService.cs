using WebApp.Models.Entities;
using WebApp.Models.Repositories;

namespace WebApp.Services
{
    public class StorehouseService
    {
        private ARepository<Storehouse> _storehouseRepo;

        public StorehouseService(ARepository<Storehouse> storehouseRepository)
        {
            _storehouseRepo = storehouseRepository;
        }

        public List<StorehouseViewModel> GetViewModelsList()
        {
            return _storehouseRepo
                .ExecuteQuery(StorehouseRepository.SelectAllQuery)
                .Select(entity => new StorehouseViewModel(entity))
                .ToList();
        }
    }

    public class StorehouseViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public StorehouseViewModel(Storehouse storehouse)
        {
            Id = storehouse.Id;
            Address = storehouse.Address;
        }
    }
}
