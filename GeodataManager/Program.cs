using Serilog;

namespace GeoDataManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = CreateHostBuilder(args).Build();
			builder.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureLogging((_, logging) => logging.ClearProviders())
				.UseSerilog((context, configuration) =>
				{
					configuration.ReadFrom.Configuration(context.Configuration);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}