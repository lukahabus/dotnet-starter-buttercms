using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ButterCMS.Starter.ViewComponents
{
    public class BlogSection : ViewComponent
    {
        private readonly BlogService blogService;

        private readonly int postsCount;

        public BlogSection(BlogService blogService, IConfiguration configuration) 
        {
            this.blogService = blogService;
            this.postsCount = Int32.Parse(configuration["BlogSection:PostsCount"]);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var postsResponse = await this.blogService.GetBlogPosts(1, this.postsCount);

            return View(postsResponse.Data);
        }
    }
}
