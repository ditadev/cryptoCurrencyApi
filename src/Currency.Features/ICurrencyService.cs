using Crypto.Model;

namespace Currency.Features;

public interface ICurrencyService
{
    public Task<PagedList<CurrencyData>> GetAllCurrencies(PageParameters parameters);
}