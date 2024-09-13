namespace Tgs.GameInterface.SabaPlus.Domains.FromProviders;

public record Game
{
	public int GameId { get; set; } = default!;
	public string GameCode { get; set; } = default!;
	public Guid GameProviderId { get; set; } = default!;
	public string GameProviderCode { get; set; } = default!;
	public string GameExternalId { get; set; } = default!;
	public GamePlatformType PlatformType { get; set; } = default!;
	public string Name { get; set; } = default!;
	public bool SubGame { get; set; } = default!;
	public bool AvailableToBrand { get; set; } = default!;
	public bool HasTurnoverOnTieBet { get; set; } = default!;
	public bool Html5 { get; set; } = default!;
	public string? Description { get; set; } = default!;
	public string? EndpointPath { get; set; } = default!;
	public string? RuleUrl { get; set; } = default!;
	public string[]? AvailableCurrencies { get; set; } = default!;
	public string? Localization { get; set; } = default!;
	public string? SubGameProviderCode { get; set; } = default!;
}
