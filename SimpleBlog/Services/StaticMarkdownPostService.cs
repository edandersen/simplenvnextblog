using SimpleBlog.Shared;
using System;
using SimpleBlog.ViewModels;
using System.Collections.Generic;
using System.IO;

namespace SimpleBlog.Services
{
    public class StaticMarkdownPostService : IPostService
    {
        private IEnumerable<PostViewModel> ReadPosts()
        {
            var posts = new List<PostViewModel>();

            var availableFiles = System.IO.Directory.GetFiles(System.IO.Path.Combine(AppContext.BaseDirectory + "\\Posts"));

            foreach (var file in availableFiles)
            {
                using (var fileReader = new StreamReader(File.OpenRead(file)))
                {
                    // check if the file begins with ---
                    if (fileReader.ReadLine() == "---")
                    {
                        var post = new PostViewModel();

                        var currentLine = fileReader.ReadLine();
                        while (currentLine != "---" && !fileReader.EndOfStream)
                        {
                            if (currentLine.StartsWith("title: "))
                            {
                                post.Title = currentLine.Replace("title: ", string.Empty);
                            }

                            currentLine = fileReader.ReadLine();
                        }

                        var remainingText = fileReader.ReadToEnd();
                        post.Body = remainingText;

                        var fileName = Path.GetFileNameWithoutExtension(file);
                        var datePortionOfName = fileName.Substring(0, 10);
                        var slugPortionOfName = fileName.Substring(10, fileName.Length - 10);

                        post.TimeStamp = DateTime.Parse(datePortionOfName);

                        posts.Add(post);
                    }

                }
                
            }

            return posts;
        }

        public IEnumerable<PostViewModel> Posts
        {
            get
            {
                return ReadPosts();
            }
        }
    }
}