using Tgs.GameInterface.SabaPlus.Core.Models;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

public record GameUrlQuery(
	ProviderInfo ProviderInfo,
	ProductInfo ProductInfo,
	CustInfo CustInfo,
	AgentInfo AgentInfo,
	string? HomeUrl = null,
	string? Additional = null);
