using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class BetResultCheckService(ISabaPlusClient client, IApiLogger logger, Settings settings) : Service(logger), IGetService<BetResultCheckQuery, BetResultCheckResult>
{
	private static readonly string _Path = "/api/CommonWallet/BetResultCheck";

	public async ValueTask<BetResultCheckResult> GetAsync(BetResultCheckQuery query, CancellationToken cancellationToken = default)
	{
		var playerCode = settings.IsProduction ? query.Player.PlayerCode : $"{query.Player.PlayerCode}_test";

		var request = new
		{
			TimeStamp = DateTime.UtcNow,
			Seq = Guid.NewGuid().ToString(),
			Payload = new
			{
				query.TicketNo,
				query.Configuration.GameType,
				OperatorCustId = playerCode,
				AgentInfo = BuildAgentInfo(query.Configuration)
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<BetResultCheckResult>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		await WriteLogAsync("BetResultCheck", new { Request = request, Query = query }, response).ConfigureAwait(false);

		return response.Payload;
	}
}
