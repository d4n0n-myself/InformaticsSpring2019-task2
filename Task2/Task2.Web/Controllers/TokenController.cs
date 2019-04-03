using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Task2.Web.Controllers
{
	public class TokenController : Controller
	{
		public IActionResult GetToken()
		{
			var identity = GetIdentity();
			if (identity == null)
				return StatusCode(500);

			var key = AuthOptions.GetSymmetricSecurityKey();
			var now = DateTime.UtcNow;
			var jwt = new JwtSecurityToken(
				AuthOptions.Issuer,
				AuthOptions.Audience,
				identity.Claims,
				now,
				now.AddMinutes(AuthOptions.Lifetime),
				new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
			var token = new JwtSecurityTokenHandler().WriteToken(jwt);
			return Ok("Bearer " + token);
		}

		private ClaimsIdentity GetIdentity()
		{
			var user = new {Login = "admin", Role = "admin", Password = "admin"};
			var claims = new List<Claim>();

			claims.Add(new Claim("Role", user.Role));

			var claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);
			return claimsIdentity;
		}
	}
}