using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Task2.Web
{
	public partial class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		///<summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		public void ConfigureServices(IServiceCollection services)
		{
			AddAuthorization(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			
			AddServices(services);
			
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("1.0.0", new OpenApiInfo()
				{
					Title = "API",
					Version = "1.0.0",
					Contact = new OpenApiContact()
					{
						Email = "danon.sibaev@yandex.ru",
						Name = "d4n0n_myself"
					},
					Description = "Informatics Spring 2019 project."
				});
			});

			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseAuthentication();

			app.UseSwagger();

			app.UseSwaggerUI(options =>
				options.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "d4n0n's API 1.0.0"));

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					"default",
					"{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.Options.StartupTimeout = new TimeSpan(0, 0, 1, 30);
					spa.UseAngularCliServer("start");
				}
			});
		}
	}
}