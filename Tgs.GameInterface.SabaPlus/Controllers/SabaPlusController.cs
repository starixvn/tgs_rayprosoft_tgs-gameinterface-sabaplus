using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.SabaPlus.Core.ApplicationServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Controllers;

[Route("sabaplus")]
[ApiController]
public class SabaPlusController : ControllerBase
{
	[HttpPost("game/url", Name = "GameUrl")]
	public ValueTask<string> GameUrlAsync(
		[FromServices] IGetService<GameUrlQuery, string> service,
		GameUrlQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);
}
