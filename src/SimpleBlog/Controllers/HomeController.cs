using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using SimpleBlog.Shared;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            return View(postService.Posts.OrderByDescending(p => p.TimeStamp));
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}