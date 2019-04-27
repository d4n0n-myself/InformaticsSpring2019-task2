using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(string title, string videoUrl, string fileLink)
        {
            if (new[] {title, videoUrl, fileLink}.Any(x => x == null))
                throw new ArgumentNullException();

            //TODO - убрать undefined с фронта
            if (videoUrl != "undefined" && !Uri.TryCreate(videoUrl, UriKind.Absolute, out var url))
                throw new ArgumentException($"Bad URL: {videoUrl}");

            _repos.Add(title, videoUrl, fileLink);
        }

        public bool ContainPost(string header)
        {
            if (header == null)
                throw new ArgumentNullException();
            return _repos.Contains(header);
        }

        public void Delete(Post post)
        {
            if (post == null)
                throw new ArgumentNullException();
            if (!_repos.Contains(post.Title))
                throw new ArgumentException($"No post with {post.Title} header");

            _repos.Delete(post);
        }

        public Post Get(string title)
        {
            if (title == null)
                throw new ArgumentNullException();

            return _repos.Get(title);
        }

        [Obsolete]
        public Post Get(Guid postId) => _repos.Get(postId);

        public Post Get(string title, Roles role)
        {
            if (role == Roles.Junior)
            {
                var enumerable = _repos.Get(title);
                enumerable.FileLink = null;
                return enumerable;
            }
            else
            {
                var enumerable = _repos.Get(title);
                return enumerable;
            }
        }

        public Post[] Get() => _repos.GetAllPosts() ?? new Post[0];

        public void Update(Post post)
        {
            if (!_repos.Contains(post.Title))
                throw new ArgumentException($"No post with {post.Title} header");

            _repos.Update(post);
        }
    }
}