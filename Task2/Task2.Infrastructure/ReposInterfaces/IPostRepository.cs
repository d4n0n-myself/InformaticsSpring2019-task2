using System;
using System.Collections.Generic;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface IPostRepository
    {
        void Add(string title, string videoUrl, string fileLink);
        void Delete(Post post);
        bool Contains(string header);
        Post Get(string title);
        Post Get(Guid postId);
        IEnumerable<Post> GetAllPosts();
        void Update(Post post);
    }
}