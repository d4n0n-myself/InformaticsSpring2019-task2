using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;
using Task2.Web.Filters;

namespace Task2.Web.Controllers
{
	[Authorize, InternalErrorFilter]
	[Route("[controller]/[action]")]
	public class CommentController : Controller
	{
		private readonly ICommentRepository _repository;

		public CommentController(ICommentRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public IActionResult Add(Comment comment)
		{
			var response = _repository.Add(comment.UserId, comment.PostId, comment.Text);
			return Ok(response);
		}

		[HttpPost]
		public IActionResult Delete(Comment comment)
		{
			var commentForDeletion = _repository.Get(comment.Text, comment.UserId, comment.PostId);
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