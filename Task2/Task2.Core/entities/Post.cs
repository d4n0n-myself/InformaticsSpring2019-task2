using System;

namespace Task2.Core.Entities
{
    public class Post
    {
        public Post(string title, string videoUrl, string fileLink)
        {
            Id = Guid.NewGuid();
            Title = title;
            VideoUrl = videoUrl;
            FileLink = fileLink;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string FileLink { get; set; }
    }
}