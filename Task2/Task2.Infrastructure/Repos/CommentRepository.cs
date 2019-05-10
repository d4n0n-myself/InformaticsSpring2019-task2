using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Infrastructure.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(User user, Guid post, string text)
        {
            _context.Comments.Add(new Comment(user.Id, post, text) {UserLogin = user.Login});
            _context.SaveChanges();
        }

        public void Delete(Guid userId, Guid postId, string text)
        {
            var commentForDeleting =
                _context.Comments.First(c => c.UserId == userId && c.PostId == postId && c.Text == text);
            _context.Comments.Remove(commentForDeleting);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll() =>
            _context.Comments.AsEnumerable();


        public IEnumerable<Comment> GetCommentsForPost(string postTitle)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Title == postTitle) ??
                       throw new ArgumentException(nameof(postTitle));
            var comments = _context.Comments.Where(c => c.PostId.Equals(post.Id)).ToArray();
            foreach (var comment in comments)
                comment.UserLogin = _context.Users.First(u => u.Id == comment.UserId)?.Login;
            return comments;
        }

        public Comment Get(Guid userId, Guid postId, string text)
        {
            return _context.Comments.FirstOrDefault(c => c.Text == text && c.PostId == postId && c.UserId == userId) ??
                   throw new ArgumentException();
        }
    }
}