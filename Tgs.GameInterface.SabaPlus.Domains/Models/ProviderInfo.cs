namespace Tgs.GameInterface.SabaPlus.Domains.Models;

public record ProviderInfo(
	Uri ApiUrl,
	string OperatorPassword,
	string OperatorSignKey);
