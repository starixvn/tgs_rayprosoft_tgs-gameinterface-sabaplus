namespace Tgs.GameInterface.SabaPlus.Core;

public class Settings
{
	public string Env { get; set; } = string.Empty;

	public bool IsProduction => string.Equals(Env, "PROD");
}
