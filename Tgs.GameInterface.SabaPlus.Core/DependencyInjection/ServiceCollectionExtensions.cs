using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tgs.GameInterface.SabaPlus.Core;
using Tgs.GameInterface.SabaPlus.Core.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameInterfaceCore(
		this IServiceCollection services)
		=> services
			.AddOptions<Settings>()
			.Configure((Settings settings, IServiceProvider service) =>
			{
				var configuration = service.GetRequiredService<IConfiguration>();

				settings.Env = configuration.GetValue<string>("Env")!;
			})
			.Services
			.AddSingleton(sp => sp.GetRequiredService<IOptions<Settings>>().Value)
			.RegisterAllServiceUtilityTypes(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient)
			.AddHttpClient<ISabaPlusClient, SabaPlusClient>()
			.Services
			.AddOptions<MongoOptions>()
			.Configure((MongoOptions options, IServiceProvider service) =>
			{
				var configuration = service.GetRequiredService<IConfiguration>();

				options.ConnectionString = configuration.GetConnectionString("Mongo")!;
			})
			.Services
			.AddSingleton<MongoConnection>()
			.AddScoped<IApiLogRepository, ApiLogRepository>()
			.AddScoped(sp => sp.GetRequiredService<MongoConnection>().Client);
}
