using System.Reflection;
using Tgs.GameInterface.SabaPlus.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameInterfaceCore(
		this IServiceCollection services)
		=> services
			.RegisterAllServiceUtilityTypes(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient)
			.AddHttpClient<ISabaPlusClient, SabaPlusClient>()
			.Services;
}
