using System.Text.Json.Serialization;

namespace Crypto.Model;

public class CurrencyPlatform
{
    [JsonIgnore]public int id { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
   [JsonIgnore] public string slug { get; set; }
    public string token_address { get; set; }
}