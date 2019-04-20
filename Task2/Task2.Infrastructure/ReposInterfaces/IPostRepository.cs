using System;
using System.Collections.Generic;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface IPostRepository
    {
        bool Add(string title, string videoUrl, string fileLink);
        bool Delete(Post post);
        bool ContainPost(string header);
        Post Get(string title);
        Post Get(Guid postId);
        IEnumerable<Post> Get();
        bool Update(Post post);
    }
}