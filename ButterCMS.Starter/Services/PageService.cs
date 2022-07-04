using System;
using System.Threading.Tasks;
using ButterCMS.Starter.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ButterCMS.Starter.Services
{
    public class PageService
    {
        private readonly ButterCMSClient client;

        private readonly string landingPageType = "landing-page";

        public PageService(ButterCMSClientService clientService)
        {
            this.client = clientService.GetClient();
        }

        public async Task<LandingPageViewModel> GetLandingPage(string pageSlug)
        {
            var response = await this.client.RetrievePageAsync<LandingPageJSONObject>(this.landingPageType, pageSlug);

            if (response == null)
            {
                return null;
            }

            var result = new LandingPageViewModel()
            {
                SEOViewModel = new SEOViewModel()
                {
                    Title = response.Data.Fields.seo.title,
                    Description = response.Data.Fields.seo.description,
                },
            };

            foreach (var item in response.Data.Fields.body)
            {
                string scrollAnchorId = this.GetStringFieldFromJson(item, "scroll_anchor_id");

                string headline = this.GetStringFieldFromJson(item, "headline");

                switch (scrollAnchorId)
                {
                    case "home":
                        result.HeroSection = new HeroSectionViewModel()
                        {
                            ScrollAnchorId = scrollAnchorId,
                            Headline = headline,
                            ButtonLabel = this.GetStringFieldFromJson(item, "button_label"),
                            ButtonUrl = this.GetStringFieldFromJson(item, "button_url"),
                            Image = this.GetStringFieldFromJson(item, "image"),
                            SubHeadline = this.GetSubHeadline(item),
                        };
                        break;

                    case "about":
                        result.AboutSection = this.MapImageWithTextSectionViewModel(item, scrollAnchorId, headline);
                        break;

                    case "tryit":
                        result.TryitSection = this.MapImageWithTextSectionViewModel(item, scrollAnchorId, headline);
                        break;

                    case "features":
                        result.FeaturesSection = new FeaturesSectionViewModel()
                        {
                            ScrollAnchorId = scrollAnchorId,
                            Headline = headline,
                            SubHeadline = this.GetSubHeadline(item),
                            Features = this.MapFeaturesViewModel(item),
                        };
                        break;

                    case "testimonials":
                        result.TestimonialsSection = new TestimonialsSectionViewModel()
                        {
                            ScrollAnchorId = scrollAnchorId,
                            Headline = headline,
                            Testimonials = this.MapTestimonialViewModel(item)
                        };
                        break;
                }
            }

            return result;
        }

        private string GetStringFieldFromJson(JObject json, string property) => (string)json["fields"][property];

        private ImageWithTextSectionViewModel MapImageWithTextSectionViewModel(JObject json, string scrollAnchorId, string headline)
            => new ImageWithTextSectionViewModel()
        {
            ScrollAnchorId = scrollAnchorId,
            Headline = headline,
            ButtonLabel = this.GetStringFieldFromJson(json, "button_label"),
            ButtonUrl = this.GetStringFieldFromJson(json, "button_url"),
            Image = this.GetStringFieldFromJson(json, "image"),
            SubHeadline = this.GetSubHeadline(json),
            ImagePosition = this.GetStringFieldFromJson(json, "image_position")
        };

        private FeatureViewModel[] MapFeaturesViewModel(JObject json)
        {
            var features = json["fields"]["features"].ToArray();

            return features.Select(feature => new FeatureViewModel()
            {
                Icon = (string)feature["icon"],
                Description = (string)feature["description"],
                Headline = (string)feature["headline"],
            }).ToArray();
        }

        private string GetSubHeadline(JObject json) => this.GetStringFieldFromJson(json, "subheadline");

        private TestimonialViewModel[] MapTestimonialViewModel(JObject json)
        {
            var testimonials = json["fields"]["testimonial"].ToArray();

            return testimonials.Select(testimonial => new TestimonialViewModel()
            {
                Title = (string)testimonial["title"],
                Quote = (string)testimonial["quote"],
                Name = (string)testimonial["name"],
            }).ToArray();
        }
    }
}
