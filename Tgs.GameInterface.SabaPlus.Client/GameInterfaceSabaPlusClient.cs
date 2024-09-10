using System.Text.Json.Serialization;
using System.Text.Json;
using Tgs.GameInterface.SabaPlus.Client.Models;
using System.Net.Http.Json;

namespace Tgs.GameInterface.SabaPlus.Client;

internal class GameInterfaceSabaPlusClient(HttpClient client) : IGameInterfaceSabaPlusClient
{
	private static readonly string _GameURL = "/sabaplus/game/url";

	private static readonly JsonSerializerOptions? _SerializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		Converters =
		{
			new JsonStringEnumConverter()
		}
	};

	public async ValueTask<string> GameUrlAsync(
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

		var response = await client.PostAsync(
			requestUri: _GameURL,
			content: content,
			cancellationToken: cancellationToken).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();

		var url = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return url;
	}
}
