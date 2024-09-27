using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;
using Tgs.GameInterface.SabaPlus.Domains.GetBetHistoryUrl;
using Tgs.GameInterface.SabaPlus.Domains.GetDailyTicketSummary;
using Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.SabaPlus.Controllers;

[Route("sabaplus")]
[ApiController]
public class SabaPlusController : ControllerBase
{
	[HttpPost("game/url", Name = "GameUrl")]
	public ValueTask<GetGameUrlResult> GameUrlAsync(
		[FromServices] IGetService<GameUrlQuery, GetGameUrlResult> service,
		GameUrlQuery source)
		=> service.GetAsync(query: source, cancellationToken: HttpContext.RequestAborted);

	[HttpPost("game/betresultcheck", Name = "BetResultCheck")]
	public ValueTask<BetResultCheckResult> BetResultCheck(
		[FromServices] IGetService<BetResultCheckQuery, BetResultCheckResult> service,
		BetResultCheckQuery source)
		=> service.GetAsync(query: source, cancellationToken: HttpContext.RequestAborted);

	[HttpPost("bethistoryurl", Name = "BetHistoryUrl")]
	public ValueTask<GetBetHistoryUrlResult> BetHistoryUrl(
	[FromServices] IGetService<BetHistoryUrlQuery, GetBetHistoryUrlResult> service,
	BetHistoryUrlQuery source)
	=> service.GetAsync(query: source, cancellationToken: HttpContext.RequestAborted);

	[HttpPost("getdailyticketsummary", Name = "GetDailyTicketSummary")]
	public ValueTask<GetDailyTicketSummaryResult> GetDailyTicketSummary(
	[FromServices] IGetService<DailyTicketSummaryQuery, GetDailyTicketSummaryResult> service,
	DailyTicketSummaryQuery source)
	=> service.GetAsync(query: source, cancellationToken: HttpContext.RequestAborted);
}
