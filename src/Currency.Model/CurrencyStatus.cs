namespace Crypto.Model;

public class CurrencyStatus
{
    public DateTime timestamp { get; set; }
    public int error_code { get; set; }
    public string error_message { get; set; }
    public int elasped { get; set; }
    public int credit_count { get; set; }
    public string notice { get; set; }
}