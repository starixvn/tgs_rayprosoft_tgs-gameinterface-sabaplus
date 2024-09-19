using System.Text.Json;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Valhalla.MessageQueue;

namespace Tgs.GameInterface.SabaPlus.Core.IntegrationServices;

internal class ApiLogger(IMessageSender sender, Settings settings) : IApiLogger
{
	public ValueTask LogAsync(APILogMessage message)
		=> sender.PublishAsync(subject: settings.LogChannel, data: JsonSerializer.Serialize(message));
}
