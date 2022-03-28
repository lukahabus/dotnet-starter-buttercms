using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class FeaturesSection : ViewComponent
    {
        public FeaturesSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
