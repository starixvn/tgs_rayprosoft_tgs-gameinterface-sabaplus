using Tgs.GameInterface.SabaPlus.Client.Models;

namespace Tgs.GameInterface.SabaPlus.Client;

internal class GameInterfaceSabaClient() : IGameInterfaceSabaClient
{
	public ValueTask<string> GameUrlAsync(
		ProviderInfo provider,
		ProductInfo product,
		CustInfo custInfo,
		AgentInfo agent,
		string? homeUrl = "",
		object? additional = null,
		CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
