using Tgs.GameInterface.SabaPlus.Core.Models;

namespace Tgs.GameInterface.SabaPlus.Core.IntegrationServices;

public interface IApiLogger
{
	void Log(APILogMessage message);
}
