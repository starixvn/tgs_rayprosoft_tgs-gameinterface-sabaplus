using Microsoft.Extensions.Options;
using Tgs.GameInterface.SabaPlus.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameInterfaceSabaPlusClient(
		this IServiceCollection services,
		Action<GameInterfaceSabaPlusClientOptions, IServiceProvider> configure)
	 => services
			.AddOptions<GameInterfaceSabaPlusClientOptions>()
			.Configure(configure)
			.Services
			.AddHttpClient<IGameInterfaceSabaPlusClient, GameInterfaceSabaPlusClient>()
			.ConfigureHttpClient((sp, client) =>
			{
				var options = sp.GetRequiredService<IOptions<GameInterfaceSabaPlusClientOptions>>().Value;

				client.BaseAddress = options.BaseUrl;
			})
			.Services;
}
