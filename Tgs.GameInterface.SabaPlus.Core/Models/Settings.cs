namespace Tgs.GameInterface.SabaPlus.Core.Models;

public class Settings
{
	public string Env { get; set; } = string.Empty;

	public bool IsProduction => string.Equals(Env, "PROD");

	public string LogChannel => $"saba.single.wallet.api.logs.{Env}";

	public Uri? Proxy { get; set; }
}
