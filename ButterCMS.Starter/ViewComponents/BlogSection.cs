using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class BlogSection : ViewComponent
    {
        public BlogSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
