using System;
using System.Collections.Generic;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface ICommentRepository
    {
        void Add(User user, Guid postId, string text);
        void Delete(Guid userId, Guid postId, string text);
        IEnumerable<Comment> GetCommentsForPost(Guid postId);
        IEnumerable<Comment> GetAll();
        Comment Get(Guid userId, Guid postId, string text);
    }
}