using Tgs.GameInterface.SabaPlus.Core.IntegrationServices;
using Tgs.GameInterface.SabaPlus.Core.Models;
using Tgs.GameInterface.SabaPlus.Domains.FromProviders;

namespace Tgs.GameInterface.SabaPlus.Core.ApplicationServices;

internal class Service(IApiLogger logger)
{
	protected static object? BuildAgentInfo(ProviderConfiguration configuration)
		=> string.IsNullOrEmpty(configuration.AgentId) ? null : new
		{
			configuration.AgentId,
			configuration.AgentKey,
			configuration.AgentCode,
			ExtraInfo = configuration.AgentExtraInfo
		};

	protected void WriteLog(string action, object request, object response)
		=> logger.Log(new APILogMessage(action, request, response));
}
