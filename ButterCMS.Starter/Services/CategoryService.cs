using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ButterCMS.Starter.Services
{
    public class CategoryService
    {
        private readonly ButterCMSClient client;

        public CategoryService(ButterCMSClientService clientService)
        {
            this.client = clientService.GetClient();
        }

        public async Task<IEnumerable<ButterCMS.Models.Category>> GetAllCategories()
        {
            return await this.client.ListCategoriesAsync();
        }

        public async Task<ButterCMS.Models.Category> FindCategory(string slug)
        {
            return await this.client.RetrieveCategoryAsync(slug);
        }
    }
}
