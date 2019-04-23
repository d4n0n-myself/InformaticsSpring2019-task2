using System;
using System.Collections.Generic;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Domain
{
    public class PostDomainService
    {
        private readonly IPostRepository _repos;

        public PostDomainService(IPostRepository repos)
        {
            _repos = repos;
        }

        public bool Add(string title, string videoUrl, string fileLink) => _repos.Add(title, videoUrl, fileLink);
        public bool ContainPost(string header) => _repos.Contains(header);
        public bool Delete(Post post) => _repos.Delete(post);
        public Post Get(string title) => _repos.Get(title);
        public Post Get(Guid postId) => _repos.Get(postId);

        public Post Get(Guid postId, Roles role)
        {
            if (role == Roles.Junior)
            {
                var enumerable = _repos.Get(postId);
                enumerable.FileLink = null;
                return enumerable;
            }
            else
            {
                var enumerable = _repos.Get(postId);
                return enumerable;
            }
        }

        public IEnumerable<Post> Get() => _repos.GetAllPosts() ?? new List<Post>();
        public bool Update(Post post) => _repos.Update(post);
    }
}