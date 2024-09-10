using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameUrlGetService : IGetService<GameUrlQuery, GetGameUrlResult>
{
	public async ValueTask<GetGameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		//var result = await client
		//	.GetSabaUrlAsync(
		//		apiUrl: query.ApiUrl,
		//		vendorId: query.VendorId,
		//		platformType: platformType,
		//		cancellationToken: cancellationToken)
		//	.ConfigureAwait(false);

		return new GetGameUrlResult(new Uri("https://google.com"));
	}
}
