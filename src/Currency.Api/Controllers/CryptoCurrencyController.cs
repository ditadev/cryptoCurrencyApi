using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crypto.Model;
using Currency.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cryptoApi.Controllers
{
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
        public async Task<ActionResult<PagedList<CurrencyData>>> GetAllCurrencies([FromQuery]PageParameters parameters)
        {
            return Ok(await _currencyService.GetAllCurrencies(parameters));
        }
    }
}
