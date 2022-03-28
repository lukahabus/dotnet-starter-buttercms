using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class AboutSection : ViewComponent
    {
        public AboutSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
