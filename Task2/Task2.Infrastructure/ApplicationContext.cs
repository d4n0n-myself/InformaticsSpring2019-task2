using Microsoft.EntityFrameworkCore;
using Task2.Core;
using Task2.Core.Entities;

namespace Task2.Infrastructure
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext()
		{
			
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(new ApplicationConfigurator().Root["ConnectionString"]);
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasIndex(u => u.Login);

			modelBuilder.Entity<Post>()
				.HasIndex(p => p.Title);
		}
		
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}