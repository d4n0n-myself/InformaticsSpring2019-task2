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
			var response = _repository.Add(text, userId, postId);
			return Ok(response);
		}

		[HttpPost]
		public IActionResult Delete([FromQuery] string userId, string postId, string text)
		{
			var commentForDeletion = _repository.Get(text, userId,  postId);
			var response = _repository.Delete(commentForDeletion);
			return Ok(response);
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