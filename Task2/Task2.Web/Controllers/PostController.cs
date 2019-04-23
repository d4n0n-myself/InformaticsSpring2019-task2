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
		public IActionResult Add([FromQuery] string title, string video, string fileLink)
		{
			_repository.Add(title, video, fileLink);
			return Ok();
		}

		[HttpGet]
		public IActionResult Contain([FromQuery] string title)
		{
			var response = _repository.ContainPost(title);
			return Ok(response);
		}

		[HttpPost]
		public IActionResult Delete([FromQuery] string title)
		{
			var post = _repository.Get(title);
			_repository.Delete(post);
			return Ok();
		}

		[HttpGet]
		public IActionResult GetPost([FromQuery] string title) =>
			Ok(_repository.Get(title));

		[HttpGet]
		public Post[] Get() => _repository.Get().ToArray();

		[HttpPost]
		public IActionResult Update(Post post)
		{
			_repository.Update(post);
			return Ok();
		}
	}
}