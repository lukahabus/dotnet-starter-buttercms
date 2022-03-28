using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class TestimonialsSection : ViewComponent
    {
        public TestimonialsSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
