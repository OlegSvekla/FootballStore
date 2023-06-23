using FootballStore.Core.Models;
using FootballStore.Infrastructure;
using FootballStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Interfaces.Services
{
    public sealed class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemViewModelService()
        {
            _catalogItemRepository = new LocalCatalogItemRepository();
        }

        public void UpdaitCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = _catalogItemRepository.GetById(viewModel.Id);
            if (existingCatalogItem is null) 
            {
                throw new Exception($"CatalogItem{viewModel.Id} was not found");
            }

            CatalogItem.CatalogItemDetails details = new(viewModel.Name, viewModel.Price);
            existingCatalogItem.UpdateDetails(details);
            _catalogItemRepository.Update(existingCatalogItem);
        }
    }
}
