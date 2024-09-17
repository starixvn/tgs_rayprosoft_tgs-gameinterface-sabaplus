using Tgs.GameInterface.SabaPlus.Core.Models;

namespace Tgs.GameInterface.SabaPlus.Core.Repositories;

public interface IApiLogRepository
{
	public Task AddAsync(APILogMessage message, CancellationToken cancellationToken = default);
}
