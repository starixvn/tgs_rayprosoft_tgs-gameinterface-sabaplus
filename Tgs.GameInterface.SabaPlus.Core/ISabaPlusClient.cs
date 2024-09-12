using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Domains.Models;

namespace Tgs.GameInterface.SabaPlus.Core;

public interface ISabaPlusClient
{
	ValueTask<SabaPlusResponse<TResponse>> PostAsync<TResponse>(
		string path,
		ProviderInfo provider,
		JsonContent body,
		CancellationToken cancellationToken = default);
}
