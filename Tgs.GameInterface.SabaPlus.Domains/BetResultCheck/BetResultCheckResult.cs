namespace Tgs.GameInterface.SabaPlus.Domains.BetResultCheck;

public class BetResultCheckResult
{
	public string TicketNo { get; set; } = default!;

	public string OperatorCustId { get; set; } = default!;

	public string GameRoundId { get; set; } = default!;

	public string TransactionId { get; set; } = default!;

	public short Status { get; set; } = default!;

	public decimal Stake { get; set; } = default!;

	public decimal ActualStake { get; set; } = default!;

	public decimal NetStake { get; set; } = default!;

	public decimal Payout { get; set; } = default!;

	public string SettleDate { get; set; } = default!;

	public string TransDate { get; set; } = default!;

	public string GameResult { get; set; } = default!;

	public decimal Odds { get; set; } = default!;

	public Dictionary<string, string> OtherBetInfo { get; set; } = default!;
}
