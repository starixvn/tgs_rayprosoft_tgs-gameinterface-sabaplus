using System.Reflection;
using Microsoft.Extensions.Configuration;
using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Core.Models;
using NATS.Client.Core;
using Tgs.MessageQueue.Nats.Serializers;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	private static readonly string _NatsKey = "Nats";

	public static IServiceCollection AddNats(this IServiceCollection services, Settings settings)
		=> services.AddKeyedSingleton(_NatsKey, (sp, _) => new NatsConnection(NatsOpts.Default with
		{
			Url = sp.GetRequiredService<IConfiguration>().GetConnectionString(_NatsKey)!,
			SerializerRegistry = TgsNatsSerializerRegistration.Default,
		}))
		.AddMessageQueue()
		.AddNatsMessageQueue(config => config.ConfigureResolveConnection(sp => sp.GetRequiredKeyedService<NatsConnection>(_NatsKey)))
		.ClearAllExchanges()
		.AddNatsGlobPatternExchange(settings.LogChannel)
		.Services;

	public static IServiceCollection AddGameInterfaceCore(
		this IServiceCollection services, Settings settings)
		=> services
			.AddSingleton(settings)
			.RegisterAllServiceUtilityTypes(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient)
			.AddHttpClient<ISabaPlusClient, SabaPlusClient>()
			.Services
			.AddNats(settings)
			.AddScoped<IApiLogger, ApiLogger>();
}
