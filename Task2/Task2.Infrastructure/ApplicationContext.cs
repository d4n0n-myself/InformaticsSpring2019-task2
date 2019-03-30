using Microsoft.EntityFrameworkCore;
using Task2.Core;

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
			base.OnModelCreating(modelBuilder);
		}
	}
}