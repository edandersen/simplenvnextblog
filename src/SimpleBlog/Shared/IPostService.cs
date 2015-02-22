using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;

namespace SimpleBlog.Shared
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> Posts { get; }
    }
}