using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Tgs.GameInterface.SabaPlus.Core;

internal class MongoConnection
{
	public IMongoClient Client { get; }

	public MongoConnection(IOptions<MongoOptions> options)
	{
		var url = new MongoUrl(options.Value.ConnectionString);

		Client = new MongoClient(url);
	}
}
