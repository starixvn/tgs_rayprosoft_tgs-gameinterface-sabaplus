using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

namespace Tgs.GameInterface.SabaPlus.Client;

public interface IGameInterfaceSabaPlusClient
{
	ValueTask<GetGameUrlResult?> GameUrlAsync(GameUrlQuery query, CancellationToken cancellationToken = default);
}
