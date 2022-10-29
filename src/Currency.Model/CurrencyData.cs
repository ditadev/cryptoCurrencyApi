namespace Crypto.Model;

public class CurrencyData
{
    public int id { get; set; }
    public int rank { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
    public string slug { get; set; }
    public int displayTV { get; set; }
    public int is_active { get; set; }
    public DateTime first_historical_data { get; set; }
    public DateTime last_historical_data { get; set; }
    public CurrencyPlatform platform { get; set; }
}