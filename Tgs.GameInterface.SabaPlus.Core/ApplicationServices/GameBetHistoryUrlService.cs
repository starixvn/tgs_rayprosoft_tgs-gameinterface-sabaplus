using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Domains.GetBetHistoryUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameBetHistoryUrlService(ISabaPlusClient client, IApiLogger logger, Settings settings) : Service(logger), IGetService<BetHistoryUrlQuery, GetBetHistoryUrlResult>
{
	private static readonly string _Path = "/api/CommonWallet/GetBetHistory";

	public async ValueTask<GetBetHistoryUrlResult> GetAsync(BetHistoryUrlQuery query, CancellationToken cancellationToken = default)
	{
		var playerCode = settings.IsProduction ? query.Player.PlayerCode : $"{query.Player.PlayerCode}_test";

		var request = new
		{
			TimeStamp = DateTime.UtcNow,
			Seq = Guid.NewGuid().ToString(),
			Payload = new
			{
				query.SettleDate,
				query.Language,
				query.GameType,
				query.ResultId,
				TicketNo = query.ExternalRoundId,
				OperatorCustId = playerCode,
				OperatorCustomerName = query.Player.Username,
				AgentInfo = BuildAgentInfo(query.Configuration),
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<GetBetHistoryUrlResult>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		await WriteLogAsync("GetBetHistoryUrl", new { Request = request, Query = query }, response).ConfigureAwait(false);

		return response.Payload ?? new GetBetHistoryUrlResult(new Uri(""));
	}
}
