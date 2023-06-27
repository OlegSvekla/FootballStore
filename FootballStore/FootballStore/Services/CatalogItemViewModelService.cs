﻿using FootballStore.Core.Models;
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
        private readonly IAppLogger<CatalogItemViewModelService> _logger;

        public CatalogItemViewModelService(IRepository<CatalogItem> catalogItemRepository,
            IAppLogger<CatalogItemViewModelService> logger)
        {
            _catalogItemRepository = catalogItemRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CatalogItemViewModel>> GetCatalogItems()
        {
            var entities = await _catalogItemRepository.GetAllAsync();

            var catalogItems = entities.Select(item => new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                PictureUrl = item.PictureUrl,
                Price = item.Price,

            }).ToList();

            return catalogItems;
        }

        public void UpdaitCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = _catalogItemRepository.GetById(viewModel.Id);
            if (existingCatalogItem is null) 
            {
                var exception = new Exception($"CatalogItem{viewModel.Id} was not found");
                _logger.LogError(exception, exception.Message);
                throw exception;
            }

            CatalogItem.CatalogItemDetails details = new(viewModel.Name, viewModel.Price);
            existingCatalogItem.UpdateDetails(details);
            _logger.LogInformation($"Updating catalog item{existingCatalogItem}." +
                $" Name {existingCatalogItem}." +
                $" Price {existingCatalogItem.Price}");
            _catalogItemRepository.Update(existingCatalogItem);
        }
    }
}
