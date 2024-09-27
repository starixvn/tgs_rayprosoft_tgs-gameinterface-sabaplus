namespace Tgs.GameInterface.SabaPlus.Domains.GetDailyTicketSummary;
public record GetDailyTicketSummaryResult
{
	public BettingData[] BettingData { get; set; } = default!;
}

public record BettingData
{
	public string CurrencyIso { get; set; } = default!;

	public int BetCount { get; set; } = default!;

	public decimal Stake { get; set; } = default!;

	public decimal ActualStake { get; set; } = default!;

	public decimal NetStake { get; set; } = default!;

	public decimal WinLose { get; set; } = default!;
}
