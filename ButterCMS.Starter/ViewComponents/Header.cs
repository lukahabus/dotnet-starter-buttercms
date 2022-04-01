using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class Header : ViewComponent
    {
        private readonly NavigationService navigationService;

        public Header(NavigationService navigationService) 
        {
            this.navigationService = navigationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await this.navigationService.GetNavigationItems());
        }
    }
}
