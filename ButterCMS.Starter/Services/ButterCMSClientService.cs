using System;
using Microsoft.Extensions.Configuration;

namespace ButterCMS.Starter.Services
{
    public class ButterCMSClientService
    {
        private readonly string apiKey;

        public ButterCMSClientService(IConfiguration configuration)
        {
            this.apiKey = configuration["ButterCMSAPIKey"];
        }

        public ButterCMSClient GetClient() => new ButterCMSClient(this.apiKey);
    }
}
