using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
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
                return BadRequest(e.ToString());
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
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult Get(Guid postId)
        {
            try
            {
                var comments = _repository.Get(postId);
                return Ok(comments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        private readonly ICommentRepository _repository;
    }
}