using FootballStore.Core.DTOs;
using FootballStore.Core.Interfaces.IRepository;
using FootballStore.Core.Interfaces.Services;

namespace FootballStore.Services
{
    public class CatalogService : ICatalogService
    {
        public readonly IRepository<CatalogItemDto> _catalogItemRepository;

        public CatalogService(IRepository<CatalogItemDto> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public void ChooseItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetAllCatalog()
        {
            var catalog = _catalogItemRepository.GetAllAsync;
        }
    }
}
