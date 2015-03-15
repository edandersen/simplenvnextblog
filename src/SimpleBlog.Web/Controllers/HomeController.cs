using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using SimpleBlog.Shared;
using System.Threading.Tasks;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        private readonly IConfigService configService;

        public HomeController(IPostService postService, IConfigService configService)
        {
            this.postService = postService;
            this.configService = configService;
        }

        public async Task<IActionResult> Index()
        {
            return await GetViewForObject(postService.Posts.OrderByDescending(p => p.TimeStamp));
        }

        public async Task<IActionResult> GetViewForObject(object model)
        {
            var config = await configService.LoadConfigAsync();

            var themeName = config.ThemeName;

            if (String.IsNullOrWhiteSpace(themeName))
            {
                // return default unthemed view
                return View(model);
            }
            else
            {
                // return the correct view taking theme into account
                return View(string.Format("~/Views/Themes/{0}/{1}/{2}", themeName, RouteData.Values["Controller"], RouteData.Values["Action"]), model);
            }
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}