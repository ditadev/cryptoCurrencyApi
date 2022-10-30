using Crypto.Model;
using Currency.Features;
using Microsoft.AspNetCore.Mvc;

namespace cryptoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CryptoCurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CryptoCurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<CurrencyResponse>>> GetAllActiveCurrencies(
        [FromQuery] PageParameters parameters)
    {
        return Ok(await _currencyService.GetAllActiveCurrencies(parameters));
    }

    [HttpGet("{symbol}")]
    public async Task<ActionResult<CurrencyResponse>> GetCurrencyBySymbol(string symbol)
    {
        return Ok(await _currencyService.GetCurrencyBySymbol(symbol));
    }
}