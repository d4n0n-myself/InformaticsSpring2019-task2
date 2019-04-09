using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
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
        public IActionResult Add(Post post)
        {
            try
            {
                var response = _repository.Add(post.Title, post.VideoUrl, post.FileLink);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetPost(string title)
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

        [HttpGet]
        public IActionResult GetAllPosts() => Ok(_repository.Get());

        [HttpPost]
        public IActionResult Delete(string title)
        {
            try
            {
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
        public IActionResult Contain(string title)
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

        private readonly IPostRepository _repository;
    }
}