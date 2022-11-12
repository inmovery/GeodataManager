using System.Reflection;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using GeoDataManager.Contracts;
using GeoDataManager.Services;
using GeoDataManager.Services.HttpRequests;
using MediatR;
using Serilog;

namespace GeoDataManager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});

			services.AddHttpClient(string.Empty, httpClient =>
			{
				var defaultAcceptHeader = new MediaTypeWithQualityHeaderValue("application/json");
				httpClient.DefaultRequestHeaders.Accept.Add(defaultAcceptHeader);

				var defaultUserAgent = new ProductInfoHeaderValue("GeoDataManager", "1.0");
				httpClient.DefaultRequestHeaders.UserAgent.Add(defaultUserAgent);
			});

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddScoped<IHttpRequestService, HttpRequestService>();
			services.AddScoped<IGeoDataService, GeoDataService>();

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			services.AddControllers();

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
				options.IncludeXmlComments(xmlCommentsPath);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoDataManager API");
					options.RoutePrefix = "";
				});
				app.UseSwagger(swaggerOptions => swaggerOptions.SerializeAsV2 = true);
			}

			app.UseCors(builder =>
			{
				builder.AllowAnyHeader()
					.AllowAnyOrigin()
					.AllowAnyMethod();
			});

			app.UseSerilogRequestLogging();

			app.UseHttpsRedirection();
			app.UseRouting();
			
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
