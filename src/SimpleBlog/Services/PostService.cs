using SimpleBlog.Shared;
using System;
using SimpleBlog.ViewModels;
using System.Collections.Generic;

namespace SimpleBlog.Services
{
    public class PostService : IPostService
    {
        public IEnumerable<PostViewModel> Posts
        {
            get
            {
                return new List<PostViewModel> { new PostViewModel() { Title = "Testing", Body = "Nice one." } };
            }
        }
    }
}