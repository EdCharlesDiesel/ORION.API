namespace ORION.StockMarket.DataAccess.Models;

public class EconomicCalendarForCreationDto
{
    public DateTime Date { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Event { get; set; } = string.Empty;

    public string Reference { get; set; } = string.Empty;

    public DateTimeOffset ReferenceDate { get; set; }

    public string Source { get; set; } = string.Empty;

    public string SourceURL { get; set; } = string.Empty;

    public string Actual { get; set; } = string.Empty;

    public string Forecast { get; set; } = string.Empty;

    public string TEForecast { get; set; } = string.Empty;

    public string URL { get; set; } = string.Empty;

    public string DateSpan { get; set; } = string.Empty;

    public int Importance { get; set; }

    public DateTimeOffset LastUpdate { get; set; }

    public string Revised { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public string Ticker { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;
}