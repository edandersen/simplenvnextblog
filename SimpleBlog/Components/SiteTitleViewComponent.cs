using Microsoft.AspNet.Mvc;
using SimpleBlog.Shared;
using System;
using System.Threading.Tasks;

namespace SimpleBlog.Components
{
    public class SiteTitleViewComponent : ViewComponent
    {
        private readonly IConfigService configService;

        public SiteTitleViewComponent(IConfigService configService)
        {
            this.configService = configService;
        }

        public async Task<string> InvokeAsync()
        {
            var config = await configService.LoadConfig();
            return config.SiteTitle;
        }
    }
}