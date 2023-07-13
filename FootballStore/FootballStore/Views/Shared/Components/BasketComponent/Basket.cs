using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FootballStore.Views.Shared.Components.BasketComponent
{
    public sealed class Basket : ViewComponent
    {
        private readonly IBasketViewModelService _basketService;
        //private readonly SignInManager<ApplicationUser> _signInManager;
    }
}
