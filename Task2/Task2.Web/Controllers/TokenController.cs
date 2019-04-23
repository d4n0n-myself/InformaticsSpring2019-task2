using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Domain;
using Task2.Web.Filters;
using Task2.Web.Services;

namespace Task2.Web.Controllers
{
	[InternalErrorFilter]
	[Route("[controller]/[action]")]
	public class TokenController : Controller
	{
		private readonly TokenService _tokenService;
		private readonly UserDomainService _userService;

		public TokenController(TokenService tokenService, UserDomainService userService)
		{
			_tokenService = tokenService;
			_userService = userService;
		}

		[HttpPost]
		public IActionResult Register([FromQuery] string username, string password)
		{
			_userService.Add(username, password, Roles.Junior);

			return Ok(new {token = $"Bearer {_tokenService.GetToken()}"});
		}

		[HttpGet]
		public IActionResult Login([FromQuery] string username, string password)
		{
			if (!_userService.ContainUser(username))
			{
				throw new ArgumentException($"Cant find user {username}");
			}

			if (!_userService.CheckPassword(username, password))
			{
				throw new ArgumentException($"Invalid credentials on {username}");
			}

			return Ok(new {token = $"Bearer {_tokenService.GetToken()}"});
		}
	}
}