using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterCMS.Starter.Models;

namespace ButterCMS.Starter.Services
{
    public class NavigationService
    {
        private readonly ButterCMSClient client;

        private readonly string navigationItemsCollectionName = "navigation_menu_item";

        public NavigationService(ButterCMSClientService clientService)
        {
            this.client = clientService.GetClient();
        }

        public async Task<IEnumerable<NavigationItemViewModel>> GetNavigationItems()
        {
            var result = await this.client.RetrieveContentFieldsAsync<NavigationItemsCollectionResponse>(new string[1] { this.navigationItemsCollectionName });

            return result.navigation_menu_item.Select(item => new NavigationItemViewModel()
            {
                Label = item.label,
                Url = item.url.Replace("#", string.Empty) // ASP.NET automatically adds # symbol
            });
        }

        class NavigationItemsCollectionResponse
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON property")]
            public IEnumerable<NavigationItemCollectionItem> navigation_menu_item { get; set; }
        }

        class NavigationItemCollectionItem
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON property")]
            public string label { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON property")]
            public string url { get; set; }
        }
    }
}
