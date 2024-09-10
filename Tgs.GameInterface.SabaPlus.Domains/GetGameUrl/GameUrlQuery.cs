using Tgs.GameInterface.SabaPlus.Domains.Models;

namespace Tgs.GameInterface.SabaPlus.Domains.GetGameUrl;

public record GameUrlQuery(
	ProviderInfo ProviderInfo,
	ProductInfo ProductInfo,
	CustInfo CustInfo,
	AgentInfo AgentInfo,
	string? HomeUrl = null,
	string? Additional = null);
