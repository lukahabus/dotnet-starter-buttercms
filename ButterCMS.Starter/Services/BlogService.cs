using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ButterCMS.Starter.Services
{
    public class BlogService
    {
        private readonly ButterCMSClient client;

        public BlogService(ButterCMSClientService clientService)
        {
            this.client = clientService.GetClient();
        }

        public async Task<ButterCMS.Models.PostsResponse> GetBlogPosts(int page, int pageSize)
        {
            return await this.client.ListPostsAsync(page, pageSize);
        }

        public async Task<IEnumerable<ButterCMS.Models.Category>> GetAllCategories()
        {
            return await this.client.ListCategoriesAsync();
        }
    }
}
