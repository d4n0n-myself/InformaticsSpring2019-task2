using System;
using System.Linq;
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
		private readonly UserDomainService _userService;

		public CommentController(CommentDomainService repository, UserDomainService userService)
		{
			_repository = repository;
			_userService = userService;
		}

		[HttpPost]
		public IActionResult Add([FromQuery] string text, string postId)
		{
			var userLoginClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserLogin") ?? throw new ArgumentException();
			var user = _userService.Get(userLoginClaim.Value);
			//TODO
			// var postId = ....
			
			_repository.Add(text, user, postId);
			return Ok();
		}

		[HttpPost]
		public IActionResult Delete([FromQuery] string userId, string postId, string text)
		{
			_repository.Delete(text, userId, postId);
			return Ok();
		}

		[HttpGet]
		public IActionResult GetByPostId([FromQuery] string postId)
		{
			if (!Guid.TryParse(postId, out var guidPostId))
				throw new ArgumentException("Failed to parse guid");
			var comments = _repository.GetCommentsForPost(guidPostId);
			return Ok(comments);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_repository.GetAll().ToArray());
		}
	}
}