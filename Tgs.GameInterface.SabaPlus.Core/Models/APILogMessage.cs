using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tgs.GameInterface.SabaPlus.Core.Models;

public class APILogMessage
{
	[BsonId]
	public ObjectId Id { get; set; } = default!;

	[BsonElement("time")]
	public DateTime Time { get; init; } = DateTime.UtcNow;

	[BsonElement("request")]
	public BsonDocument Request { get; set; } = default!;

	[BsonElement("response")]
	public BsonDocument Response { get; set; } = default!;

	public string Action { get; set; } = default!;

	public APILogMessage(string action, object request, object response)
	{
		var options = new JsonSerializerOptions()
		{
			WriteIndented = true,
		};

		if (request is not null)
		{
			Request = BsonDocument.Parse(JsonSerializer.Serialize(request, options));
		}

		if (response is not null)
		{
			Response = BsonDocument.Parse(JsonSerializer.Serialize(response, options));
		}

		Action = action;
	}
}
