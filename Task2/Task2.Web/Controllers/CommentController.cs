using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add(Comment comment)
        {
            try
            {
                var response = _repository.Add(comment.UserId, comment.PostId, comment.Text);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Delete(Comment comment)
        {
            try
            {
                var _comment = _repository.Get(comment.Text, comment.UserId, comment.PostId);
                var response = _repository.Delete(_comment);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string postId)
        {
            try
            {
                if (!Guid.TryParse(postId, out var guidPostId))
                    throw new ArgumentException("Failed to parse guid");
                var comments = _repository.Get(guidPostId);
                return Ok(comments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }
    }
}