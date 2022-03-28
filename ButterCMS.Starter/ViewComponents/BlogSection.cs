using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ButterCMS.Starter.ViewComponents
{
    public class BlogSection : ViewComponent
    {
        private readonly ButterCMSClient client;

        private readonly int postsCount;

        public BlogSection(ButterCMSClientService clientService, IConfiguration configuration) 
        {
            this.client = clientService.GetClient();
            this.postsCount = Int32.Parse(configuration["BlogSection:PostsCount"]);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var postsResponse = await this.GetBlogPosts(1, this.postsCount);

            return View(postsResponse.Data);
        }

        private async Task<ButterCMS.Models.PostsResponse> GetBlogPosts(int page, int pageSize)
        {
            return await this.client.ListPostsAsync(page, pageSize);
        }
    }
}
