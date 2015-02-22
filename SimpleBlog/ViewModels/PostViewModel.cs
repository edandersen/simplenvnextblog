using System;

namespace SimpleBlog.ViewModels
{
    public class PostViewModel
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Author { get; set; }
    }
}