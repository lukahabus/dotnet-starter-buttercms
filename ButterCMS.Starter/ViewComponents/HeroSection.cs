using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class HeroSection : ViewComponent
    {
        public HeroSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
