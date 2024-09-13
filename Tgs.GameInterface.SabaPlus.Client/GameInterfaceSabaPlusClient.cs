using System.Net.Http.Json;
using System.Text.Json;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

namespace Tgs.GameInterface.SabaPlus.Client;

internal class GameInterfaceSabaPlusClient(HttpClient client) : IGameInterfaceSabaPlusClient
{
	private static readonly string _GameURL = "/sabaplus/game/url";

	private static readonly JsonSerializerOptions? _SerializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	public async ValueTask<GetGameUrlResult?> GameUrlAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		var content = JsonContent.Create(query, options: _SerializerOptions);
		var response = await client.PostAsync(_GameURL, content, cancellationToken).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();

		var data = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<GetGameUrlResult>(data, _SerializerOptions);
	}
}
