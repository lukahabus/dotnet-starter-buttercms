using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ButterCMS.Starter.Services
{
    public class TagService
    {
        private readonly ButterCMSClient client;

        public TagService(ButterCMSClientService clientService)
        {
            this.client = clientService.GetClient();
        }

        public async Task<ButterCMS.Models.Tag> FindTag(string tagSlug)
        {
            return await this.client.RetrieveTagAsync(tagSlug);
        }
    }
}
