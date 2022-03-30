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

        public async Task<IEnumerable<ButterCMS.Models.Post>> GetBlogPosts(int page = 1, int pageSize = 10)
        {
            var posts = await this.client.ListPostsAsync(page, pageSize);

            return posts.Data;
        }

        public async Task<IEnumerable<ButterCMS.Models.Post>> SearchBlogPosts(string query)
        {
            var posts = await this.client.SearchPostsAsync(query);

            return posts.Data;
        }

        public async Task<IEnumerable<ButterCMS.Models.Post>> GetBlogPostsByCategory(string categorySlug, int page = 1, int pageSize = 10)
        {
            var posts = await this.client.ListPostsAsync(page, pageSize, false, null, categorySlug);

            return posts.Data;
        }

        public async Task<IEnumerable<ButterCMS.Models.Post>> GetBlogPostsByTag(string tagSlug, int page = 1, int pageSize = 10)
        {
            var posts = await this.client.ListPostsAsync(page, pageSize, false, null, null, tagSlug);

            return posts.Data;
        }
    }
}
