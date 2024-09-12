using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameUrlGetService(ISabaPlusClient client) : IGetService<GameUrlQuery, GetGameUrlResult>
{
	private static readonly string _Path = "/api/CommonWallet/LaunchGame";

	public async ValueTask<GetGameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		var request = new
		{
			TimeStamp = DateTime.UtcNow,
			Seq = Guid.NewGuid().ToString(),
			Payload = new
			{
				query.ProductInfo,
				query.CustInfo,
				query.AgentInfo,
				query.HomeUrl,
				query.Additional
			}
		};
		var content = JsonContent.Create(request);
		var response = await client.PostAsync<GameUrlPayload>(_Path, query.ProviderInfo, content, cancellationToken).ConfigureAwait(false);

		return new GetGameUrlResult(response.Payload.ReturnUrl);
	}
}
