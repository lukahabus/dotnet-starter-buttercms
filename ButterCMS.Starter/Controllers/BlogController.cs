using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterCMS.Starter.Models;
using ButterCMS.Starter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.Controllers
{
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
                    }
                };

                return View(viewModel);
            }

            if (categorySlug != null)
            {
                var viewModel = new BlogIndexViewModel
                {
                    Posts = await blogService.GetBlogPostsByCategory(categorySlug),
                    NavigationState = new BlogPostsByCategoryNavigationState
                    {
                        Category = await this.categoryService.FindCategory(categorySlug)
                    }
                };

                return View(viewModel);
            }

            if (tagSlug != null)
            {
                var viewModel = new BlogIndexViewModel
                {
                    Posts = await blogService.GetBlogPostsByTag(tagSlug),
                    NavigationState = new BlogPostsByTagNavigationState
                    {
                        Tag = await this.tagService.FindTag(tagSlug)
                    }
                };

                return View(viewModel);
            }

            return View(new BlogIndexViewModel
            {
                Posts = await this.blogService.GetBlogPosts(),
                NavigationState = new AllBlogPostsNavigationState()
            });
        }

        [HttpGet("{slug}")]
        public ActionResult Post(string slug)
        {
            return View();
        }
    }
}