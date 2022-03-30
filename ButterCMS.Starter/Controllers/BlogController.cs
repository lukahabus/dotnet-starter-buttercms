using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ButterCMS.Starter.Controllers
{
    public class BlogController : Controller
    {
        [Route("[controller]")]
        public ActionResult BlogPostsList()
        {
            return View();
        }

        [Route("[controller]/{slug}")]
        public ActionResult GetBlogPost(string slug)
        {
            return View();
        }
    }
}