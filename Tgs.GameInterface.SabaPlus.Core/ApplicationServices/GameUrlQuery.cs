namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

public record GameUrlQuery(
	Uri ApiUrl,
	string OperatorPassword,
	string OperatorSignKey,

	string GameType,
	string GameId,

	string PlayerCode,
	string PlayerName,
	string Language,
	string Platform,
	string Currency,
	string IP,
	string WalletSideToken);
