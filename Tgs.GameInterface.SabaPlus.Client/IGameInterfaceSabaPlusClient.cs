using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.GameInterface.SabaPlus.Domains.Models;

namespace Tgs.GameInterface.SabaPlus.Client;

public interface IGameInterfaceSabaPlusClient
{
	ValueTask<GetGameUrlResult?> GameUrlAsync(
		ProviderInfo provider,
		ProductInfo product,
		CustInfo custInfo,
		AgentInfo agent,
		string? homeUrl = "",
		object? additional = null,
		CancellationToken cancellationToken = default);
}
