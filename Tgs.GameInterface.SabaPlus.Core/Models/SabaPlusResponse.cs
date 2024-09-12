namespace Tgs.GameInterface.SabaPlus.Core.Models;

public class SabaPlusResponse<TPayload>
{
	public string TimeStamp { get; set; } = default!;

	public string Seq { get; set; } = default!;

	public string Message { get; set; } = default!;

	public int ErrorCode { get; set; } = default;

	public string ErrorMessage { get; set; } = default!;

	public TPayload Payload { get; set; } = default!;
}
