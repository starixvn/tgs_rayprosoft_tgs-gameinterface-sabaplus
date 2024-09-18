using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Core.Repositories;
using Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class BetResultCheckService(ISabaPlusClient client, IApiLogRepository apiLog, Settings settings) : IGetService<BetResultCheckQuery, BetResultCheckResult>
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
				AgentInfo = BuildAgentInfo(query)
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<BetResultCheckResult>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		await WriteLogAsync(new { Request = request, Query = query }, response, cancellationToken).ConfigureAwait(false);

		return response.Payload;
	}

	private static object? BuildAgentInfo(BetResultCheckQuery query)
		=> string.IsNullOrEmpty(query.Configuration.AgentId) ? null : new
		{
			query.Configuration.AgentId,
			query.Configuration.AgentKey,
			query.Configuration.AgentCode,
			ExtraInfo = query.Configuration.AgentExtraInfo
		};

	private async Task WriteLogAsync(object request, object response, CancellationToken cancellationToken)
	{
		await apiLog.AddAsync(new APILogMessage("BetResultCheck", request, response), cancellationToken).ConfigureAwait(true);
	}
}
