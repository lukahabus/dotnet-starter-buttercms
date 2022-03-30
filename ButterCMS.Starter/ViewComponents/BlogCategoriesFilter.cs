using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class BlogCategoriesFilter : ViewComponent
    {
        private readonly BlogService blogService;

        public BlogCategoriesFilter(BlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await this.blogService.GetAllCategories());
        }
    }
}
