using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Core.IntegrationServices;

internal class SabaPlusClient(HttpClient client) : ISabaPlusClient
{
	public async ValueTask<SabaPlusResponse<TResponse>> PostAsync<TResponse>(
		string path,
		ProviderConfiguration configuration,
		JsonContent content,
		CancellationToken cancellationToken = default)
	{
		try
		{
			client.BaseAddress = configuration.ApiUrl;

			var raw = await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			var hashed = MD5.HashData(Encoding.UTF8.GetBytes($"{raw}{configuration.OperatorSignKey}"));
			var signed = Convert.ToHexString(hashed);

			content.Headers.Add("operator-sign", signed);
			content.Headers.Add("operator-pwd", configuration.OperatorPassword);

			var response = await client.PostAsync(path, content, cancellationToken).ConfigureAwait(false);

			response.EnsureSuccessStatusCode();

			var dataInString = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			var data = JsonConvert.DeserializeObject<SabaPlusResponse<TResponse>>(dataInString);

			if (data.ErrorCode != 0)
			{
				SentrySdk.CaptureException(new Exception(dataInString));
			}

			return data;
		}
		catch (Exception ex)
		{
			SentrySdk.CaptureException(ex);

			return new SabaPlusResponse<TResponse>();
		}
	}
}
