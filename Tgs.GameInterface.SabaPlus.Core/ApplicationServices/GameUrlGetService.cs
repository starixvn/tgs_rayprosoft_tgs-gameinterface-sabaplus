using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Domains.FromProviders;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameUrlGetService(ISabaPlusClient client, IApiLogger logger, Settings settings) : Service(logger), IGetService<GameUrlQuery, GetGameUrlResult>
{
	private static readonly string _Path = "/api/CommonWallet/LaunchGame";

	public async ValueTask<GetGameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		var walletToken = $"{query.Game.GameProviderCode}@{query.Game.GameId}@{Guid.NewGuid()}";
		var playerCode = settings.IsProduction ? query.Player.PlayerCode : $"{query.Player.PlayerCode}_test";

		var request = new
		{
			TimeStamp = DateTime.UtcNow,
			Seq = Guid.NewGuid().ToString(),
			Payload = new
			{
				ProductInfo = new
				{
					query.Configuration.GameType,
					GameId = query.Game.GameExternalId,
					//AppType = GetAppType(query.Game.PlatformType) TODO: Need discuss more
				},
				CustInfo = new
				{
					query.Query.Language,
					query.Query.ExtraInfo.BrowserUserAgent,
					OperatorCustomerId = playerCode,
					OperatorCustomerName = query.Player.Username,
					Platform = GetUserPlatform(query.Query.PlatformType),
					CurrencyISO = query.Currency,
					IpAddress = query.Query.IPAddress,
					WalletSideToken = walletToken
				},
				AgentInfo = BuildAgentInfo(query.Configuration),
				HomeUrl = query.Query.BackUrl.ToString(),
				query.Configuration.Additional
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<GetGameUrlResult>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		await WriteLogAsync("GetGameUrl", new { Request = request, Query = query }, response).ConfigureAwait(false);

		return response.Payload;
	}

	private static string GetUserPlatform(PlatformType type)
		=> type switch
		{
			PlatformType.Desktop => "D",
			PlatformType.Mobile => "M",
			_ => "M",
		};

	//private static string GetAppType(GamePlatformType type)
	//	=> type switch
	//	{
	//		GamePlatformType.Desktop => "D",
	//		GamePlatformType.Mobile => "M",
	//		GamePlatformType.DesktopAndMobile => "M",
	//		_ => "M",
	//	};
}
