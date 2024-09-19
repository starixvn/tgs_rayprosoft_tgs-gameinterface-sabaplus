namespace Tgs.GameInterface.SabaPlus.Core.Models;

public class APILogMessage(string action, object request, object response)
{
	public object Request { get; set; } = request;

	public object Response { get; set; } = response;

	public string Action { get; set; } = action;

	public string GameProviderCode { get; init; } = "SABAPLUS";
}
