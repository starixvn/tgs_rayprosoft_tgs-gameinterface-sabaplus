using Tgs.GameInterface.SabaPlus.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameInterfaceSabaPlusClient(
		this IServiceCollection services,
		Action<GameInterfaceSabaClientOptions, IServiceProvider> configure)
	 => services
			.AddOptions<GameInterfaceSabaClientOptions>()
			.Configure(configure)
			.Services
			.AddTransient<IGameInterfaceSabaClient, GameInterfaceSabaClient>();
}
