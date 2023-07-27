using FootballStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Interfaces.Services
{
    public interface ICatalogItemViewModelService
    {
        public void UpdaitCatalogItem(CatalogItemViewModel viewModel);
        Task <CatalogIndexViewModel> GetCatalogItems(int? brandId, int?typeId);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}