using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class GameUrlGetService : IGetService<GameUrlQuery, string>
{
	public async ValueTask<string> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
	{
		//var result = await client
		//	.GetSabaUrlAsync(
		//		apiUrl: query.ApiUrl,
		//		vendorId: query.VendorId,
		//		platformType: platformType,
		//		cancellationToken: cancellationToken)
		//	.ConfigureAwait(false);

		return "https://google.com";
	}
}
