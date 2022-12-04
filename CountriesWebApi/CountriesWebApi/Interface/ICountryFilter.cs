using CountriesWebApi.Models;
using System.Collections;

namespace CountriesWebApi.Interface
{
    public interface ICountryFilter
    {
        public IEnumerable<Country> GetOnlyEuropeanUnionCountries(List<Country> countriesList);
        public IEnumerable<Country> GetSortedCountriesByPopulation(List<Country> countryList);
        public IEnumerable<Country> GetSortedCountriesByPopulationDensity(List<Country> countryList);
        public IEnumerable GetAllInfoAboutCountry(List<Country> countryList); 
    }
}
