namespace Tgs.GameInterface.SabaPlus.Client.Models;

public record ProviderInfo(
	Uri ApiUrl,
	string OperatorPassword,
	string OperatorSignKey);
