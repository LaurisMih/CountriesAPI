using CountriesWebApi.Interface;
using CountriesWebApi.Service;
using CountriesWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApi.Controllers
{
    [Route("CountriesApi")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly ICountryApi _countries;
        //private readonly IValidation _validation;
        private readonly IApiService _service;
        public CountryApiController(ICountryApi countries, /*IValidation validation*/ IApiService service)
        {
            _countries = countries;
           // _validation = validation;
            _service = service;
        }

        [HttpGet]
        [Route("TopTenByPopulation")]
        public async Task<IActionResult> GetTopTenCountriesByPopulation()
        {
            var getAllEuCountries = await _countries.GetCountries();
          
            return Ok(_service.SortByPopulation(getAllEuCountries).Take(10));
        }

        [HttpGet]
        [Route("TopTenByPopulationDensity")]
        public async Task<IActionResult> GetTopTenCountriesByPopulationDensity()
        {
            var getAllEuCountries = await _countries.GetCountries();

            return Ok(_service.SortByPopulationDensity(getAllEuCountries).Take(10));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> FindInfoAboutCountryByName(string name)
        {
            var getCountryByName = await _countries.GetCountryByName(name);
            
           

            return Ok(_service.FindAllInfoAboutCountry(getCountryByName));
        }
    }
}