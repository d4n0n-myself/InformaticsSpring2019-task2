using System;
using System.Collections.Generic;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface ICommentRepository
    {
        bool Add(Guid userId, Guid postId, string text);
        bool Delete(Comment comment);
        IEnumerable<Comment> GetCommentsForPost(Guid postId);
        Comment Get(string text, Guid userId, Guid postId);
    }
}