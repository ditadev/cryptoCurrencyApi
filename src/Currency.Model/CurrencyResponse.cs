namespace Crypto.Model;

public class CurrencyResponse
{
    public int Rank { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public int IsActive { get; set; }
    public CurrencyPlatform Platformlatform { get; set; }
    
}