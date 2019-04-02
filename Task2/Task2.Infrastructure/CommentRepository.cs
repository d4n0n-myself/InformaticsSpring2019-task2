using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Core.entities;

namespace Task2.Infrastructure
{
    public class CommentRepository
    {
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public CommentRepository()
        {
            _context = new ApplicationContext();
        }
        public bool Add(Guid userId, Guid postId, string text)
        {
            try
            {
                _context.Comments.Add(new Comment(userId, postId, text));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(Comment comment)
        {
            try
            {
                var commentForDeleting = _context.Comments.First(c => c.Id.Equals(comment.Id));
                _context.Comments.Remove(commentForDeleting);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public IEnumerable<Comment> Get(Guid postId)
        {
            var comments = _context.Comments.Where(c => c.PostId.Equals(postId));
            foreach (var comment in comments)
                comment.UserLogin = _context.Users.First(u => u.Id == comment.UserId)?.Login;
            return comments;
        }
        
        private readonly ApplicationContext _context;
    }
}