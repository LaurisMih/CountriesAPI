using CountriesWebApi.Models;
using System.Collections;

namespace CountriesWebApi.Interface
{
    public interface IApiService
    {
        public IEnumerable<Country> OnlyEuropeanUnionCountries(List<Country> countriesList);
        public IEnumerable<Country> SortByPopulation(List<Country> countryList);
        public IEnumerable<Country> SortByPopulationDensity(List<Country> countryList);
        public IEnumerable FindAllInfoAboutCountry(List<Country> countryList); 
    }
}
