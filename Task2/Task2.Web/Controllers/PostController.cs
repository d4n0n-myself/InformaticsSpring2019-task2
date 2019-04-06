using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var title = form["title"];
                var videoUrl = form["video_url"];
                var fileLink = form["file_link"];
                var response = _repository.Add(title, videoUrl, fileLink);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult Contain([FromQuery] string title)
        {
            try
            {
                var response = _repository.ContainPost(title);
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
                var title = form["title"];
                var post = _repository.Get(title);
                var response = _repository.Delete(post);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            try
            {
                return Ok(_repository.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetPost([FromQuery] string title)
        {
            try
            {
                var post = _repository.Get(title);
                return Ok(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }
    }
}