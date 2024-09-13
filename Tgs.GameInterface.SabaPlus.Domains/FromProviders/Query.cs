namespace Tgs.GameInterface.SabaPlus.Domains.FromProviders;

public record ExtraInfo
{
	public string BrowserUserAgent { get; init; } = default!;
}

public record Query
{
	public string PlayerCode { get; init; } = default!;
	public int GameId { get; init; } = default!;
	public string LoginRecordId { get; init; } = default!;
	public PlatformType PlatformType { get; init; } = default!;
	public string Language { get; init; } = default!;
	public string IPAddress { get; init; } = default!;
	public Uri BackUrl { get; init; } = default!;
	public ExtraInfo ExtraInfo { get; init; } = default!;
}
