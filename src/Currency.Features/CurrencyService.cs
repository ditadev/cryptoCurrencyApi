using System.Net;
using System.Text.Json;
using System.Web;
using Crypto.Model;

namespace Currency.Features;

public class CurrencyService:ICurrencyService
{
    
    private static string API_KEY = "f72256d5-8a4e-48ab-b13b-f40f30f60c72";

    public async Task<PagedList<CurrencyData>> GetAllCurrencies(PageParameters parameters)
    {
        var result = await MakeApiCall();
        var currencyData = result.data;
        var currencyList = new List<CurrencyData>();

        foreach (var data in currencyData)
        {
            currencyList.Add(data);
        }
        
        return await PagedList<CurrencyData>.ToPagedList(currencyList,parameters.PageNumber,parameters.PageSize);
    }

    public Task<Crypto.Model.Currency?> MakeApiCall()
    {
        var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");

        var queryString = HttpUtility.ParseQueryString(string.Empty);

        URL.Query = queryString.ToString();

        var client = new WebClient();
        client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
        client.Headers.Add("Accepts", "application/json");
       
        var response = client.DownloadString(URL.ToString());
        var result = JsonSerializer.Deserialize<Crypto.Model.Currency>(response);

        return Task.FromResult(result);
    }
}