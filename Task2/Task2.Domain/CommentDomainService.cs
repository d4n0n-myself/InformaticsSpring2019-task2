using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Domain
{
    public class CommentDomainService
    {
        private readonly ICommentRepository _repository;

        public CommentDomainService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public void Add(string text, string userId, string postId)
        {
            var (guidUserId, guidPostId) = CheckAndParseArguments(text, userId, postId);
            _repository.Add(guidUserId, guidPostId, text);
        }

        public void Delete(string text, string userId, string postId)
        {
            var (guidUserId, guidPostId) = CheckAndParseArguments(text, userId, postId);
            _repository.Delete(guidUserId, guidPostId, text);
        }

        public IEnumerable<Comment> GetCommentsForPost(Guid postId)
        {
            if (postId == Guid.Empty)
                throw new ArgumentException(nameof(postId));
            return _repository.GetCommentsForPost(postId);
        }

        public Comment Get(string text, string userId, string postId)
        {
            var (guidUserId, guidPostId) = CheckAndParseArguments(text, userId, postId);
            return _repository.Get(guidUserId, guidPostId, text);
        }

        private (Guid guidUserId, Guid guidPostId) CheckAndParseArguments(string text, string userId, string postId)
        {
            if (new[] {text, userId, postId}.Any(x => x == null))
                throw new ArgumentNullException();
            return TryParseGuids(userId, postId);
        }

        private (Guid guidUserId, Guid guidPostId) TryParseGuids(string userId, string postId)
        {
            if (!Guid.TryParse(userId, out var guidUserId))
                throw new ArgumentException(nameof(userId));
            if (!Guid.TryParse(postId, out var guidPostId))
                throw new ArgumentException(nameof(postId));
            return (guidUserId, guidPostId);
        }
    }
}