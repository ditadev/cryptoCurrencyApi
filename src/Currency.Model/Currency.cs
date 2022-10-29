using System.Text.Json;

namespace Crypto.Model;

public class Currency
{
    public CurrencyStatus status { get; set; }
    public CurrencyData[] data { get; set; }
    //
    // public override string ToString()
    // {
    //     return JsonSerializer.Serialize(this);
    // }
}