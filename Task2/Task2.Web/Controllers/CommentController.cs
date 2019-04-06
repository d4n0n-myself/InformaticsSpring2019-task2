using System;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var text = form["text"];
                var userId = Guid.Parse(form["user_id"]);
                var postId = Guid.Parse(form["post_id"]);
                var response = _repository.Add(userId, postId, text);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult Delete()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var text = form["text"];
                var userId = Guid.Parse(form["user_id"]);
                var postId = Guid.Parse(form["post_id"]);
                var comment = _repository.Get(text, userId, postId);
                var response = _repository.Delete(comment);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
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
                return BadRequest(e.ToString());
            }
        }
    }
}