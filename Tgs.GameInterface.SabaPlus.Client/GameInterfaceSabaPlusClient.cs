using System.Net.Http.Json;
using System.Text.Json;
using Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

namespace Tgs.GameInterface.SabaPlus.Client;

internal class GameInterfaceSabaPlusClient(HttpClient client) : IGameInterfaceSabaPlusClient
{
	private static readonly string _GameURL = "/sabaplus/game/url";
	private static readonly string _BetResultCheck = "/sabaplus/game/betresultcheck";

	private static readonly JsonSerializerOptions? _SerializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	public ValueTask<GetGameUrlResult?> GameUrlAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
		=> PostAync<GameUrlQuery, GetGameUrlResult>(_BetResultCheck, query, cancellationToken);

	public ValueTask<BetResultCheckResult?> BetResultCheck(BetResultCheckQuery query, CancellationToken cancellationToken = default)
		=> PostAync<BetResultCheckQuery, BetResultCheckResult>(_BetResultCheck, query, cancellationToken);

	private async ValueTask<TResult?> PostAync<TQuery, TResult>(string action, TQuery query, CancellationToken cancellationToken)
	{
		var content = JsonContent.Create(query, options: _SerializerOptions);
		var response = await client.PostAsync(action, content, cancellationToken).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();

		var data = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<TResult>(data, _SerializerOptions);
	}
}
