using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.IdentityModel.Tokens;

namespace Task2.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class TokenController : Controller
	{
		private readonly TokenService _tokenService;

		public TokenController(TokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost]
		public IActionResult Register([FromQuery] string username, string password)
		{
			//Users.AddNew
			if (username == "1")
				return Ok("gfy");
				
			return Ok( new { token = $"Bearer {_tokenService.GetToken()}" });
		}

		[HttpGet]
		public IActionResult Login([FromQuery] string username, string password)
		{
			// Users.Login // check credentials
			
			return Ok( new { token = $"Bearer {_tokenService.GetToken()}" });
		}
	}
}