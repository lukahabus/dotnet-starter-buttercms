using System;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.Controllers
{
    public class ErrorController : Controller
    {
        [Route("{controller}/404")]
        public IActionResult NotFoundError()
        {
            return View("NotFound");
        }

        [Route("{controller}/401")]
        public IActionResult UnauthorizedError()
        {
            return View("Unauthorized");
        }
    }
}
