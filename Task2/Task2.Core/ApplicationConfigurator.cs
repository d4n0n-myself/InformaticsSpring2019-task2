using Microsoft.Extensions.Configuration;

namespace Task2.Core
{
	public class ApplicationConfigurator
	{
		public IConfigurationRoot Root { get; set; }

		public ApplicationConfigurator()
		{
			Root = new ConfigurationBuilder()
				.AddJsonFile("appconfig.json")
				.Build();
		}
	}
}