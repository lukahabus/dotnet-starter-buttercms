using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.ViewComponents
{
    public class TryitSection : ViewComponent
    {
        public TryitSection()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
