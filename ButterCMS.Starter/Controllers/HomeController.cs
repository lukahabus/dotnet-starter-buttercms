using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ButterCMS.Starter.Models;
using Microsoft.Extensions.Configuration;
using ButterCMS.Starter.Services;
using ButterCMS.Starter.Attributes;

namespace ButterCMS.Starter.Controllers
{
    [TypeFilter(typeof(WithApiKeyAttribute))]
    public class HomeController : Controller
    {
        private readonly string defaultLandingPageSlug;

        private readonly PageService pageService;

        public HomeController(IConfiguration configuration, PageService pageService)
        {
            this.defaultLandingPageSlug = configuration["DefaultLandingPageSlug"];

            this.pageService = pageService;
        }

        [Route("/")]
        [Route("/landing-page/{slug}")]
        public async Task<IActionResult> Index(string slug = null)
        {
            var viewModel = await this.pageService.GetLandingPage(slug ?? this.defaultLandingPageSlug);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
