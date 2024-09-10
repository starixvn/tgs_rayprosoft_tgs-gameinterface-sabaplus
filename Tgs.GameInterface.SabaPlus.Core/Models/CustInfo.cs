namespace Tgs.GameInterface.SabaPlus.Core.Models;

public record CustInfo(
	string OperatorCustomerId,
	string OperatorCustomerName,
	string Language,
	string Platform,
	string CurrencyISO,
	string BrowserUserAgent,
	string IpAddress,
	string WalletSideToken);
