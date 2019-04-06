using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
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
        public IActionResult GetPost()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var title = form["title"];
                var post = _repository.Get(title);
                return Ok(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetAllPosts() => Ok(_repository.Get());

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
        public IActionResult Contain()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var title = form["title"];
                var response = _repository.ContainPost(title);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        private readonly IPostRepository _repository;
    }
}