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

        public async Task<ActionResult> Index()
        {
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

        [Route("blog/category/{slug}", Name = "BlogPostsByCategory")]
        public async Task<ActionResult> PostsByCategory(string slug)
        {
            var category = await this.categoryService.FindCategory(slug);

            var viewModel = new BlogIndexViewModel
            {
                Posts = await blogService.GetBlogPostsByCategory(slug),
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

            return View("Index", viewModel);
        }

        [Route("blog/tag/{slug}", Name = "BlogPostsByTag")]
        public async Task<ActionResult> PostsByTag(string slug)
        {
            var tag = await this.tagService.FindTag(slug);

            var viewModel = new BlogIndexViewModel
            {
                Posts = await blogService.GetBlogPostsByTag(slug),
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

            return View("Index", viewModel);
        }

        [Route("{controller}/{action}")]
        public async Task<ActionResult> Search(string q)
        {
            var viewModel = new BlogIndexViewModel
            {
                Posts = await blogService.SearchBlogPosts(q),
                NavigationState = new SearchedBlogPostsNavigationState
                {
                    SearchText = q
                },
                SEOViewModel = new SEOViewModel()
                {
                    Title = ComposePageTitle($"search result for {q}"),
                    Description = ComposePageDescription($"search results for {q}"),
                },
            };

            return View("Index", viewModel);
        }

        [Route("blog/{slug}", Name = "BlogPost")]
        public async Task<ActionResult> Post(string slug)
        {
            return View(await this.blogService.GetBlogPost(slug));
        }

        private string ComposePageTitle(string type) => $"Sample Blog - {type}";

        private string ComposePageDescription(string type) => $"Sample blog powered by ButterCMS, showing {type}";
    }
}