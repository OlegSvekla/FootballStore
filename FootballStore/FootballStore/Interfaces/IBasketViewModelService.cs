using FootballStore.Core.Models;
using FootballStore.Pages.Basket;

namespace FootballStore.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOnCreateBasketForUser(string userName);

        Task<int> CourtTotalBasketItems(string userName);

        Task<BasketViewModel> Map(Basket basket);
    }
}
