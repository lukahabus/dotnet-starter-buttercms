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

namespace ButterCMS.Starter.Controllers
{
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
            return View(await this.pageService.GetLandingPage(slug ?? this.defaultLandingPageSlug));
        }
    }
}
