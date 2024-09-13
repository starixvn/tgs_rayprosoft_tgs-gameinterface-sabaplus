namespace Tgs.GameInterface.SabaPlus.Domains.FromProviders;

public record ProviderConfiguration
{
	public string Code { get; set; } = default!;
	public Uri ApiUrl { get; set; } = default!;
	public string OperatorPassword { get; set; } = default!;
	public string OperatorSignKey { get; set; } = default!;
	public string? AgentId { get; set; } = default!;
	public string? AgentKey { get; set; } = default!;
	public string? AgentCode { get; set; } = default!;
	public string? AgentExtraInfo { get; set; } = default!;
	public object? Additional { get; set; } = default!;
	public string GameType { get; set; } = default!;
}
