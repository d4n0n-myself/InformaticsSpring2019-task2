using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Domain;
using Task2.Web.Filters;

namespace Task2.Web.Controllers
{
//	[Authorize]
	[InternalErrorFilter]
	[Route("[controller]/[action]")]
	public class CommentController : Controller
	{
		private readonly CommentDomainService _repository;

		public CommentController(CommentDomainService repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public IActionResult Add([FromQuery] string userId, string postId, string text)
		{
			_repository.Add(text, userId, postId);
			return Ok();
		}

		[HttpPost]
		public IActionResult Delete([FromQuery] string userId, string postId, string text)
		{
			_repository.Delete(text, userId, postId);
			return Ok();
		}

		[HttpGet]
		public IActionResult Get([FromQuery] string postId)
		{
			if (!Guid.TryParse(postId, out var guidPostId))
				throw new ArgumentException("Failed to parse guid");
			var comments = _repository.GetCommentsForPost(guidPostId);
			return Ok(comments);
		}
	}
}