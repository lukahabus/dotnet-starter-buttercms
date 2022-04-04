using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace ButterCMS.Starter.Attributes
{
    public class WithApiKeyAttribute : Attribute, IActionFilter
    {
        private readonly IConfiguration configuration;

        public WithApiKeyAttribute(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (this.configuration["ButterCMS:APIKey"] == null)
                context.Result = new UnauthorizedResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
