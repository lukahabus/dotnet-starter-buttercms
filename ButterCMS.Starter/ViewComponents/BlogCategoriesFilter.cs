using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class BlogCategoriesFilter : ViewComponent
    {
        private readonly CategoryService categoryService;

        public BlogCategoriesFilter(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await this.categoryService.GetAllCategories());
        }
    }
}
