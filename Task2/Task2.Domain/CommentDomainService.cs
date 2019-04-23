using System;
using System.Collections.Generic;
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

        public bool Add(string text, string userId, string postId)
        {
            var (guidUserId, guidPostId) = TryParseGuids(userId, postId);
            return _repository.Add(guidUserId, guidPostId, text);
        }


        public bool Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsForPost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Comment Get(string text, string userId, string postId)
        {
            var (guidUserId, guidPostId) = TryParseGuids(userId, postId);
            return _repository.Get(text, guidUserId, guidPostId);
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