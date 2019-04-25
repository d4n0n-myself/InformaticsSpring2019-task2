using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Task2.Web
{
	public class TokenService
	{
		public string GetToken()
		{
			var identity = GetIdentity();

			var key = AuthOptions.GetSymmetricSecurityKey();
			var now = DateTime.Now;
			var jwt = new JwtSecurityToken(
				AuthOptions.Issuer,
				AuthOptions.Audience,
				identity.Claims,
				now,
				now.AddMinutes(AuthOptions.Lifetime),
				new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
			var token = new JwtSecurityTokenHandler().WriteToken(jwt);
			return token;
		}

		private ClaimsIdentity GetIdentity()
		{
			var user = new {Login = "admin", Role = "admin", Password = "admin"};
			var claims = new List<Claim> {new Claim("Role", user.Role)};

			var claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);
			return claimsIdentity;
		}
	}
}