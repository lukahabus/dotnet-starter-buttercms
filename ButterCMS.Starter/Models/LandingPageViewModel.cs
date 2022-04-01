using System;
using Newtonsoft.Json.Linq;

namespace ButterCMS.Starter.Models
{
    public class LandingPageViewModel
    {
        public SEOViewModel SEOViewModel { get; set; }

        public HeroSectionViewModel HeroSection { get; set; }
    }

    public abstract class LandingPageSection
    {
        public string ScrollAnchorId { get; set; }

        public string Headline { get; set; }
    }

    public class HeroSectionViewModel : LandingPageSection
    {
        public string ButtonUrl { get; set; }

        public string SubHeadline { get; set; }

        public string ButtonLabel { get; set; }

        public string Image { get; set; }
    }

    public class LandingPageJSONObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON propery")]
        public SEOJSONObject seo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "JSON propery")]
        public JObject[] body { get; set; }
    }
}
