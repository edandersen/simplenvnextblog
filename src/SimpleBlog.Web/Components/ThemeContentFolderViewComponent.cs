using Microsoft.AspNet.Mvc;
using SimpleBlog.Shared;
using System;
using System.Threading.Tasks;

namespace SimpleBlog.Components
{
    public class ThemeContentFolderViewComponent : ViewComponent
    {
        private readonly IConfigService configService;

        public ThemeContentFolderViewComponent(IConfigService configService)
        {
            this.configService = configService;
        }

        public async Task<string> InvokeAsync()
        {
            var config = await configService.LoadConfigAsync();
            var themeName = config.ThemeName ?? string.Empty;
            return "/themes/" + themeName;
        }
    }
}