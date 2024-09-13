using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Domains.FromProviders;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameUrlGetService(ISabaPlusClient client) : IGetService<GameUrlQuery, GetGameUrlResult>
{
	private static readonly string _Path = "/api/CommonWallet/LaunchGame";

	public async ValueTask<GetGameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		var walletToken = $"{query.Game.GameProviderCode}@{query.Game.GameId}@{Guid.NewGuid()}";

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
					AppType = GetAppType(query.Game.PlatformType)
				},
				CustInfo = new
				{
					query.Query.Language,
					query.Query.ExtraInfo.BrowserUserAgent,
					OperatorCustomerId = query.Player.PlayerCode,
					OperatorCustomerName = query.Player.Username,
					Platform = GetUserPlatform(query.Query.PlatformType),
					CurrencyISO = query.Currency,
					IpAddress = query.Query.IPAddress,
					WalletSideToken = walletToken
				},
				AgentInfo = new
				{
					query.Configuration.AgentId,
					query.Configuration.AgentKey,
					query.Configuration.AgentCode,
					ExtraInfo = query.Configuration.AgentExtraInfo
				},
				HomeUrl = query.Query.BackUrl.ToString(),
				query.Configuration.Additional
			}
		};

		var content = JsonContent.Create(request);
		var response = await client.PostAsync<GameUrlPayload>(_Path, query.Configuration, content, cancellationToken).ConfigureAwait(false);

		return new GetGameUrlResult(response.Payload.ReturnUrl);
	}

	private static string GetAppType(GamePlatformType type)
		=> type switch
		{
			GamePlatformType.Desktop => "D",
			GamePlatformType.Mobile => "M",
			GamePlatformType.DesktopAndMobile => "M",
			_ => "M",
		};

	private static string GetUserPlatform(PlatformType type)
		=> type switch
		{
			PlatformType.Desktop => "D",
			PlatformType.Mobile => "M",
			_ => "M",
		};
}
