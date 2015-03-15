using Microsoft.AspNet.Mvc;
using SimpleBlog.Shared;
using System;
using System.Threading.Tasks;

namespace SimpleBlog.Components
{
    public class ThemeNameViewComponent : ViewComponent
    {
        private readonly IConfigService configService;

        public ThemeNameViewComponent(IConfigService configService)
        {
            this.configService = configService;
        }

        public async Task<string> InvokeAsync()
        {
            var config = await configService.LoadConfigAsync();
            return config.ThemeName ?? string.Empty;
        }
    }
}