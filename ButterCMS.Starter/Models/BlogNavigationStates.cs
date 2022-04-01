using System;
using ButterCMS.Models;

namespace ButterCMS.Starter.Models
{
    public interface IBlogNavigationState
    {
        string NavigationTitle { get; }

        string NavigationItemText { get; }
    }

    public class AllBlogPostsNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "All Blog Posts";

        public string NavigationItemText { get; } = "All blog posts";
    }

    public class BlogPostsByCategoryNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "Blog Posts by Category";

        public Category Category { get; set; }

        public string NavigationItemText
        {
            get
            {
                return $"Category: {Category.Name}";
            }
        }
    }

    public class BlogPostsByTagNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "Blog Posts by Tag";

        public Tag Tag { get; set; }

        public string NavigationItemText
        {
            get
            {
                return $"Tag: {Tag.Name}";
            }
        }
    }

    public class SearchedBlogPostsNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "Search Results";

        public string SearchText { get; set; }

        public string NavigationItemText
        {
            get
            {
                return $"Search: {SearchText}";
            }
        }
    }

    public class BlogPostNavigationState : IBlogNavigationState
    {
        public string NavigationTitle
        {
            get
            {
                return Post.Title;
            }
        }

        public Post Post { get; set; }

        public string NavigationItemText
        {
            get
            {
                return Post.Title;
            }
        }
    }
}
