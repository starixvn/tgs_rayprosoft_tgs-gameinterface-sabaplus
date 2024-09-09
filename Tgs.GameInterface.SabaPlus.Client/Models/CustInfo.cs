namespace Tgs.GameInterface.SabaPlus.Client.Models;

public record CustInfo(
	string OperatorCustomerId,
	string OperatorCustomerName,
	string Language,
	string Platform,
	string CurrencyISO,
	string BrowserUserAgent,
	string IpAddress,
	string WalletSideToken);
