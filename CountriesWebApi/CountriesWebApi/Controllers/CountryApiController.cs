using CountriesWebApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApi.Controllers
{
    [Route("CountriesApi")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly ICountryApi _countries;
        private readonly ICountryValidation _validation;
        private readonly ICountryFilter _filter;
       
        public CountryApiController(ICountryApi countries, ICountryValidation validation, ICountryFilter service)
        {
           _countries = countries;
           _validation = validation;
           _filter = service;       
        }

        [HttpGet]
        [Route("TopTenByPopulation")]
        public async Task<IActionResult> GetTopTenCountriesByPopulation()
        {
            var euCountries = await _countries.GetEuCountries();
          
            return Ok(_filter.GetSortedCountriesByPopulation(euCountries).Take(10));
        }

        [HttpGet]
        [Route("TopTenByPopulationDensity")]
        public async Task<IActionResult> GetTopTenCountriesByPopulationDensity()
        {
            var euCountries = await _countries.GetEuCountries();

            return Ok(_filter.GetSortedCountriesByPopulationDensity(euCountries).Take(10));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> FindInfoAboutCountryByName(string name)
        {
           var getEuCountryByName = await _countries.GetCountryByName(name);
           var getAllEuCountries = await _countries.GetEuCountries();
           var isCountryValid = getEuCountryByName.FirstOrDefault(c => c.Name == name);

           if (isCountryValid == null || !_validation.CountryIsValid(getAllEuCountries, isCountryValid))
           {
               return BadRequest($"{name} is not an EU country");
           }

           return Ok(_filter.GetAllInfoAboutCountry(getEuCountryByName));
        }
    }
}