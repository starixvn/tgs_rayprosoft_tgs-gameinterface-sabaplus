using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Domains.GetDailyTicketSummary;
public record DailyTicketSummaryQuery
{
	public string GameType { get; set; } = default!;

	public int TimeZone { get; set; } = default!;

	public DateTime TargetDate { get; set; } = default!;

	public ProviderConfiguration Configuration { get; set; } = default!;
}
