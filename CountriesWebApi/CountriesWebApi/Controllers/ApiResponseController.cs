using CountriesWebApi.Interface;
using CountriesWebApi.MainLogic;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApi.Controllers
{
    [Route("countriesApi")]
    [ApiController]
    public class CountriesApi : ControllerBase
    {
        private readonly ICountryApi _countries;

        public CountriesApi(ICountryApi countries)
        {
            _countries = countries;
        }

        [HttpGet]
        [Route("TopTenByPopulation")]
        public async Task<IActionResult> GetTopTenCountriesByPopulation()
        {
            var getAllEuCountries = await _countries.GetCountries();

            return Ok(MainApiLogic.SortByPopulation(getAllEuCountries).Take(10));
        }

        [HttpGet]
        [Route("TopTenByPopulationDensity")]
        public async Task<IActionResult> GetTopTenCountriesByPopulationDensity()
        {
            var getAllEuCountries = await _countries.GetCountries();

            return Ok(MainApiLogic.SortByPopulationDensity(getAllEuCountries).Take(10));
        }

    }
}