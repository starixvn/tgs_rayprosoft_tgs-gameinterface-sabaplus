using Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;
using Tgs.GameInterface.SabaPlus.Domains.GetBetHistoryUrl;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

namespace Tgs.GameInterface.SabaPlus.Client;

public interface IGameInterfaceSabaPlusClient
{
	ValueTask<GetGameUrlResult?> GameUrlAsync(GameUrlQuery query, CancellationToken cancellationToken = default);

	ValueTask<BetResultCheckResult?> BetResultCheck(BetResultCheckQuery query, CancellationToken cancellationToken = default);

	ValueTask<GetBetHistoryUrlResult?> BetHistoryUrl(BetHistoryUrlQuery query, CancellationToken cancellationToken = default);
}
