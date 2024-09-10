namespace Tgs.GameInterface.SabaPlus.Core.Models;

public record ProviderInfo(
	Uri ApiUrl,
	string OperatorPassword,
	string OperatorSignKey);
