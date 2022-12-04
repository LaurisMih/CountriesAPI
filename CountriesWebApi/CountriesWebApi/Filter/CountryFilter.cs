using CountriesWebApi.Interface;
using CountriesWebApi.Models;
using System.Collections;

namespace CountriesWebApi.Filter
{ 
    public class CountryFilter : ICountryFilter
    {
        public IEnumerable<Country> GetOnlyEuropeanUnionCountries(List<Country> countriesList)
        {
            var europeanUnionCountries = countriesList.Where(c => c.Independent);

            return europeanUnionCountries;
        }

        public  IEnumerable<Country> GetSortedCountriesByPopulation(List<Country> countryList)
        {
            var europeanUnionCountries = GetOnlyEuropeanUnionCountries(countryList);
            var sortByPopulationTop10 = europeanUnionCountries.OrderByDescending(c => c.Population);

            return sortByPopulationTop10;
        }

        public IEnumerable<Country> GetSortedCountriesByPopulationDensity(List<Country> countryList)
        {
            var europeanUnionCountries = GetOnlyEuropeanUnionCountries(countryList);
            
            var sortByPopulationDensityTop10 = europeanUnionCountries.OrderByDescending(c => c.Population / c.Area);

            return sortByPopulationDensityTop10;
        }

        public IEnumerable GetAllInfoAboutCountry(List<Country> countryList)
        {
            var findInfo = countryList.Select(c => new {
               
                c.NativeName, 
                c.Area, 
                c.Population,
                c.TopLevelDomain,
                c.Independent,
            });

            return findInfo;
        }
    }
}
