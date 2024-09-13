using System.Net.Http.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Core;

public interface ISabaPlusClient
{
	ValueTask<SabaPlusResponse<TResponse>> PostAsync<TResponse>(
		string path,
		ProviderConfiguration configuration,
		JsonContent body,
		CancellationToken cancellationToken = default);
}
