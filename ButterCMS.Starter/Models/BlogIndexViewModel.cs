using System;
using System.Collections.Generic;

namespace ButterCMS.Starter.Models
{
    public class BlogIndexViewModel
    {
        public IBlogNavigationState NavigationState { get; set; }

        public IEnumerable<ButterCMS.Models.Post> Posts { get; set; }
    }
}
