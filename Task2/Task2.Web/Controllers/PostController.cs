using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Domain;
using Task2.Web.Filters;

namespace Task2.Web.Controllers
{
    [Authorize, InternalErrorFilter]
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly PostDomainService _repository;

        public PostController(PostDomainService repository)
        {
            _repository = repository;
        }

		[Authorize("Admin")]
        [HttpPost]
        public IActionResult Add([FromQuery] string title, string genre, string performer, string video,
            string fileLink)
        {
            video = video.Replace("watch?v=", "embed/");
            _repository.Add(title, (Genre) Enum.Parse(typeof(Genre), genre), performer, video, fileLink);
            return Ok();
        }

        [HttpGet]
        public IActionResult Contain([FromQuery] string title)
        {
            var response = _repository.ContainPost(title);
            return Ok(response);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Delete([FromQuery] string title)
        {
            var post = _repository.Get(title);
            _repository.Delete(post);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPost([FromQuery] string title)
        {
            var roleClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Role") ??
                            throw new ArgumentException("No role");
            return Ok(_repository.Get(title, Enum.Parse<Roles>(roleClaim.Value)));
        }

        [HttpGet]
        public Post[] Get() => _repository.Get();

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Update(Post post)
        {
            _repository.Update(post);
            return Ok();
        }
    }
}