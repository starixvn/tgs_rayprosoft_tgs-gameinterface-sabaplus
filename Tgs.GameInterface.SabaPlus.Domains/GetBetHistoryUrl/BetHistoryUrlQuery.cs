using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Domains.GetBetHistoryUrl;

public record BetHistoryUrlQuery
{
	public string GameType { get; set; } = default!;

	public string ExternalRoundId { get; set; } = default!;

	public string ResultId { get; set; } = default!;

	public string Language { get; set; } = default!;

	public DateTime SettleDate { get; set; } = default!;

	public Player Player { get; set; } = default!;

	public ProviderConfiguration Configuration { get; set; } = default!;
}
