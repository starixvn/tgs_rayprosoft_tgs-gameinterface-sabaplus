using System.Text.Json.Serialization;
using System.Text.Json;
using Tgs.GameInterface.SabaPlus.Domains.Models;
using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

namespace Tgs.GameInterface.SabaPlus.Client;

internal class GameInterfaceSabaPlusClient(HttpClient client) : IGameInterfaceSabaPlusClient
{
	private static readonly string _GameURL = "/sabaplus/game/url";

	private static readonly JsonSerializerOptions? _SerializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	public async ValueTask<GetGameUrlResult?> GameUrlAsync(
		ProviderInfo provider,
		ProductInfo product,
		CustInfo custInfo,
		AgentInfo agent,
		string? homeUrl = "",
		object? additional = null,
		CancellationToken cancellationToken = default)
	{
		var request = new
		{
			ProviderInfo = provider,
			ProductInfo = product,
			CustInfo = custInfo,
			AgentInfo = agent,
			HomeUrl = homeUrl,
			Additional = additional,
		};

		var content = JsonContent.Create(request, options: _SerializerOptions);
		var response = await client.PostAsync(_GameURL, content, cancellationToken).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();

		var data = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<GetGameUrlResult>(data, _SerializerOptions);
	}
}
