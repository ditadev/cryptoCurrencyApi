using Crypto.Model;

namespace Currency.Features;

public interface ICurrencyService
{
    public Task<PagedList<CurrencyResponse>> GetAllActiveCurrencies(PageParameters parameters);
    public Task<CurrencyResponse> GetCurrencyBySymbol(string symbol);
    public Task<Crypto.Model.Currency?> MakeApiCall();
}