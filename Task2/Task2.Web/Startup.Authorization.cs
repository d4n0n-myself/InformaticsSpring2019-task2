using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Task2.Web
{
	public partial class Startup
	{
		public void AddAuthorization(IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = AuthOptions.Issuer,
					ValidateAudience = true,
					ValidAudience = AuthOptions.Audience,
					ValidateLifetime = true,
					IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
					ValidateIssuerSigningKey = true,
				};
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("Admin",
					policy => { policy.RequireClaim("Role", "Admin"); });
				options.AddPolicy("Junior",
					policy => { policy.RequireClaim("Role", "Junior", "Middle","Senior", "Admin"); });
				options.AddPolicy("Middle",
					policy => { policy.RequireClaim("Role", "Middle","Senior", "Admin"); });
				options.AddPolicy("Senior",
					policy => { policy.RequireClaim("Role", "Senior", "Admin"); });
				options.AddPolicy("All",
					policy => { policy.RequireClaim("Role"); });
			});
		}
	}
}