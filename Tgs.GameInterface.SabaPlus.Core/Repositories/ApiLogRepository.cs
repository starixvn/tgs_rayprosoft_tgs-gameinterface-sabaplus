using System.Threading;
using MongoDB.Driver;
using Tgs.GameInterface.SabaPlus.Core.Models;

namespace Tgs.GameInterface.SabaPlus.Core.Repositories;

internal class ApiLogRepository(IMongoClient client) : IApiLogRepository
{
	public async Task AddAsync(APILogMessage message, CancellationToken cancellationToken = default)
	{
		var collection = GetCollection(message.Action);

		await collection.InsertOneAsync(
			document: message,
			cancellationToken: cancellationToken)
			.ConfigureAwait(false);
	}

	private IMongoCollection<APILogMessage> GetCollection(string action)
		=> client
			.GetDatabase($"sabaplus_interface_logs")
			.GetCollection<APILogMessage>($"{action.ToLower()}_logs");
}
