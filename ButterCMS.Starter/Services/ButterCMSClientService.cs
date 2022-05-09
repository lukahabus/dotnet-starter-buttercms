using System;
using Microsoft.Extensions.Configuration;

namespace ButterCMS.Starter.Services
{
    public class ButterCMSClientService
    {
        private readonly string apiKey;

        private readonly bool preview;

        public ButterCMSClientService(IConfiguration configuration)
        {
            this.apiKey = configuration["ButterCMSAPIKey"];
            this.preview = bool.Parse(configuration["ButterCMSPreview"]);
        }

        public ButterCMSClient GetClient() => new ButterCMSClient(this.apiKey, null, 3, null, this.preview);
    }
}
