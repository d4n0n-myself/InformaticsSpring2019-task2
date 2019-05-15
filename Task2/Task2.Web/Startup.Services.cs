using Microsoft.Extensions.DependencyInjection;
using Task2.Domain;
using Task2.Infrastructure;
using Task2.Infrastructure.Repos;
using Task2.Infrastructure.ReposInterfaces;
using Task2.Web.Services;

namespace Task2.Web
{
	public partial class Startup
	{
		public void AddServices(IServiceCollection services)
		{
			services.AddScoped<ApplicationContext>();

			services.AddScoped<IPostRepository, PostRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICommentRepository, CommentRepository>();

			services.AddScoped<UserDomainService>();
			services.AddScoped<PostDomainService>();
			services.AddScoped<CommentDomainService>();
			services.AddScoped<TokenService>();
		}
	}
}