using System;
namespace ButterCMS.Starter.Models
{
    public class SEOViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class SEOJSONObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON property")]
        public string title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON property")]
        public string description { get; set; }
    }
}
