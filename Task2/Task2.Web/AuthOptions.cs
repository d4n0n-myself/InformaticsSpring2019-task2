using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Task2.Web
{
	public class AuthOptions
	{
		public const string Issuer = "AuthServer";
		public const string Audience = "http://localhost:5000/";
		public const string Key = "mysupersecret_secretkey!123";
		public const int Lifetime = 120;
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
	}
}