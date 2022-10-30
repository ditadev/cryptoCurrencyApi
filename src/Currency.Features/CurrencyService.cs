using System.Net;
using System.Text.Json;
using System.Web;
using Crypto.Model;

namespace Currency.Features;

public class CurrencyService : ICurrencyService
{
    private readonly AppSettings _appSettings;

    public CurrencyService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task<PagedList<CurrencyResponse>> GetAllActiveCurrencies(PageParameters parameters)
    {
        var result = await MakeApiCall();
        var currencyData = result.data;
        var currencyList = new List<CurrencyResponse>();

        foreach (var data in currencyData)
        {
            var newCurrency = new CurrencyResponse
            {
                Rank = data.rank,
                Symbol = data.symbol,
                Name = data.name,
                Price = data.priceUsd,
                MaxSupply = data.maxSupply,
                CirculatingSupply = data.supply,
                Explorer = data.explorer
            };
            currencyList.Add(newCurrency);
        }

        return await PagedList<CurrencyResponse>.ToPagedList(currencyList, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<CurrencyResponse> GetCurrencyBySymbol(string symbol)
    {
        var result = await MakeApiCall();
        var currencyData = result.data;

        foreach (var data in currencyData)
        {
            var newCurrency = new CurrencyResponse
            {
                Rank = data.rank,
                Symbol = data.symbol,
                Name = data.name,
                Price = data.priceUsd,
                MaxSupply = data.maxSupply,
                CirculatingSupply = data.supply,
                Explorer = data.explorer
            };

            if (newCurrency.Symbol == symbol.ToUpper())
                return newCurrency;
        }

        return null;
    }

    public Task<Crypto.Model.Currency?> MakeApiCall()
    {
        var URL = new UriBuilder("api.coincap.io/v2/assets");

        var queryString = HttpUtility.ParseQueryString(string.Empty);

        URL.Query = queryString.ToString();

        var client = new WebClient();
        client.Headers.Add("Authorization", "Bearer " + _appSettings.ApiKey);
        client.Headers.Add("Accepts", "application/json");

        var response = client.DownloadString(URL.ToString());
        var result = JsonSerializer.Deserialize<Crypto.Model.Currency>(response);

        return Task.FromResult(result);
    }
}