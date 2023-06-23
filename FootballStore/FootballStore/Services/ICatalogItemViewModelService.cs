using FootballStore.ViewModels;
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
    }
}
