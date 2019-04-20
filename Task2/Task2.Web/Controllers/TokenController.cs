using Microsoft.AspNetCore.Mvc;
using Task2.Web.Filters;
using Task2.Web.Services;

namespace Task2.Web.Controllers
{
	[InternalErrorFilter]
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