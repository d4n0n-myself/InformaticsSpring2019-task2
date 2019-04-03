using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Core.entities;

namespace Task2.Infrastructure
{
    public class PostRepository
    {
        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PostRepository()
        {
            _context = new ApplicationContext();
        }
        
        public bool Add(string title, string videoUrl, string fileLink)
        {
            try
            {
                if (_context.Posts.Any(p => p.Title == title)) throw new ArgumentException("Name already exists!");
                _context.Posts.Add(new Post(title, videoUrl, fileLink));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(Post post)
        {
            try
            {
                var postForDeleting = _context.Posts.First(p => p.Id.Equals(post.Id));
                _context.Posts.Remove(postForDeleting);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public bool ContainPost(string header) => _context.Posts.Any(p => p.Title.Equals(header));

        public Post Get(string title) => _context.Posts.First(p => p.Title.Equals(title));
        
        public Post Get(Guid postId) => _context.Posts.First(p => p.Id.Equals(postId));
       
        public List<Post> Get() => _context.Posts.ToList();
        
        private readonly ApplicationContext _context;
    }
}