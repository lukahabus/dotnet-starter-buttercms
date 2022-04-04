using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterCMS.Starter.Attributes;
using ButterCMS.Starter.Models;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.Controllers
{
    [TypeFilter(typeof(WithApiKeyAttribute))]
    public class BlogController : Controller
    {
        private readonly BlogService blogService;

        private readonly CategoryService categoryService;

        private readonly TagService tagService;

        public BlogController(BlogService blogService, CategoryService categoryService, TagService tagService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
            this.tagService = tagService;
        }

        public async Task<ActionResult> Index(string searchQuery = null, string categorySlug = null, string tagSlug = null)
        {
            if (searchQuery != null)
            {
                var viewModel = new BlogIndexViewModel
                {
                    Posts = await blogService.SearchBlogPosts(searchQuery),
                    NavigationState = new SearchedBlogPostsNavigationState
                    {
                        SearchText = searchQuery
                    },
                    SEOViewModel = new SEOViewModel()
                    {
                        Title = ComposePageTitle($"search result for {searchQuery}"),
                        Description = ComposePageDescription($"search results for {searchQuery}"),
                    },
                };

                return View(viewModel);
            }

            if (categorySlug != null)
            {
                var category = await this.categoryService.FindCategory(categorySlug);

                var viewModel = new BlogIndexViewModel
                {
                    Posts = await blogService.GetBlogPostsByCategory(categorySlug),
                    NavigationState = new BlogPostsByCategoryNavigationState
                    {
                        Category = category
                    },
                    SEOViewModel = new SEOViewModel()
                    {
                        Title = ComposePageTitle($"category: {category.Name}"),
                        Description = ComposePageDescription($"category: {category.Name}"),
                    },
                };

                return View(viewModel);
            }

            if (tagSlug != null)
            {
                var tag = await this.tagService.FindTag(tagSlug);

                var viewModel = new BlogIndexViewModel
                {
                    Posts = await blogService.GetBlogPostsByTag(tagSlug),
                    NavigationState = new BlogPostsByTagNavigationState
                    {
                        Tag = tag
                    },
                    SEOViewModel = new SEOViewModel()
                    {
                        Title = ComposePageTitle($"tag: {tag.Name}"),
                        Description = ComposePageDescription($"tag: {tag.Name}"),
                    },
                };

                return View(viewModel);
            }

            return View(new BlogIndexViewModel
            {
                Posts = await this.blogService.GetBlogPosts(),
                NavigationState = new AllBlogPostsNavigationState(),
                SEOViewModel = new SEOViewModel()
                {
                    Title = ComposePageTitle("All posts"),
                    Description = ComposePageDescription("all posts"),
                },
            });
        }

        [Route("{controller}/{action}/{slug}")]
        public async Task<ActionResult> Post(string slug)
        {
            return View(await this.blogService.GetBlogPost(slug));
        }

        private string ComposePageTitle(string type) => $"Sample Blog - {type}";

        private string ComposePageDescription(string type) => $"Sample blog powered by ButterCMS, showing {type}";
    }
}