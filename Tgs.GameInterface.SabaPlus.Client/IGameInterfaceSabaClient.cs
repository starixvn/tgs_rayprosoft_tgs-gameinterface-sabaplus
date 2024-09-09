using Tgs.GameInterface.SabaPlus.Client.Models;

namespace Tgs.GameInterface.SabaPlus.Client;

public interface IGameInterfaceSabaClient
{
	ValueTask<string> GameUrlAsync(
		ProviderInfo provider,
		ProductInfo product,
		CustInfo custInfo,
		AgentInfo agent,
		string? homeUrl = "",
		object? additional = null,
		CancellationToken cancellationToken = default);
}
