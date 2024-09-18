using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;

public record BetResultCheckQuery
{
	public Player Player { get; set; } = default!;

	public ProviderConfiguration Configuration { get; set; } = default!;

	public string TicketNo { get; set; } = default!;
}
