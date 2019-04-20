using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Task2.Core.Entities;
using Task2.Domain;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly PostDomainService _repository;

        public PostController(PostDomainService repository)
        {
            repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromQuery] string title, string video, string fileLink)
        {
            try
            {
                var response = _repository.Add(title, video, fileLink);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [Authorize("All")]
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

        [HttpGet]
        public Post[] Get()
        {
            try
            {
                return _repository.Get().ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

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
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IActionResult Contain([FromQuery]string title)
        {
            try
            {
                var response = _repository.ContainPost(title);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}