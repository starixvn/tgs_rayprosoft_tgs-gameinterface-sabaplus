using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Domains.GetDailyTicketSummary;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class DailyTicketSummaryService(ISabaPlusClient client, IApiLogger logger)
	: Service(logger), IGetService<DailyTicketSummaryQuery, GetDailyTicketSummaryResult>
{
	private static readonly string _Path = "/api/OperatorApi/GetDailyTicketSummary";

	public async ValueTask<GetDailyTicketSummaryResult> GetAsync(DailyTicketSummaryQuery query, CancellationToken cancellationToken = default)
	{
		var request = new
		{
			TimeStamp = DateTime.UtcNow,
			Seq = Guid.NewGuid().ToString(),
			Payload = new
			{
				query.GameType,
				query.TimeZone,
				query.TargetDate
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<GetDailyTicketSummaryResult>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		await WriteLogAsync("GetDailyTicketSummary", new { Request = request, Query = query }, response).ConfigureAwait(false);

		return response.Payload;
	}
}
