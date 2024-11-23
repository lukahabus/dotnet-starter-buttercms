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
        public string NavigationTitle { get; } = "Svi događaji";

        public string NavigationItemText { get; } = "Svi događaji";
    }

    public class BlogPostsByCategoryNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "Događaji po kategorijama";

        public Category Category { get; set; }

        public string NavigationItemText
        {
            get
            {
                return $"Kategorija: {Category.Name}";
            }
        }
    }

    public class BlogPostsByTagNavigationState : IBlogNavigationState
    {
        public string NavigationTitle { get; } = "Događaji po tagovima";

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
        public string NavigationTitle { get; } = "Rezultati pretrage";

        public string SearchText { get; set; }

        public string NavigationItemText
        {
            get
            {
                return $"Pretraga: {SearchText}";
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
