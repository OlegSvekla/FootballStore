using FootballStore.Core.Models;
using FootballStore.Interfaces;
using FootballStore.Pages.Basket;

namespace FootballStore.Services
{
    public sealed class BasketViewModelService : IBasketViewModelService
    {
        public Task<int> CourtTotalBasketItems(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketViewModel> GetOnCreateBasketForUser(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketViewModel> Map(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}