using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

public record GameUrlQuery
{
	public Query Query { get; set; } = default!;

	public Game Game { get; set; } = default!;

	public Player Player { get; set; } = default!;

	public ProviderConfiguration Configuration { get; set; } = default!;

	public string Currency { get; set; } = default!;
}
