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

        public Post Get(Guid postId)
        {
            return _repos.Get(postId);
        }

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

        public bool Update(Post post)
        {
            return _repos.Update(post);
        }

        public bool Add(string title, string videoUrl, string fileLink)
        {
            return _repos.Add(title, videoUrl, fileLink);
        }

        public bool Delete(Post post)
        {
            return _repos.Delete(post);
        }

        public bool ContainPost(string header)
        {
            return _repos.Contains(header);
        }

        public Post Get(string title)
        {
            return _repos.Get(title);
        }


        public IEnumerable<Post> Get()
        {
            return _repos.GetAllPosts();
        }
    }
}