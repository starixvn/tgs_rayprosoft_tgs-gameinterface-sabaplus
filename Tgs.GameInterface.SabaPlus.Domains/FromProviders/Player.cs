namespace Tgs.GameInterface.SabaPlus.Domains.FromProviders;

public record Player
{
	public Guid ResellerId { get; set; } = default!;
	public string ResellerCode { get; set; } = default!;
	public Guid LicenseeId { get; set; } = default!;
	public string LicenseeCode { get; set; } = default!;
	public Guid BrandId { get; set; } = default!;
	public string BrandCode { get; set; } = default!;
	public string PlayerCode { get; set; } = default!;
	public string Username { get; set; } = default!;
	public Guid DefaultWalletId { get; set; } = default!;
	public string DefaultWalletCurrencyCode { get; set; } = default!;
}
