using CountriesWebApi.Interface;
using CountriesWebApi.Models;
using System.Collections;

namespace CountriesWebApi.Service
{ 
    public class ApiService : IApiService
    {

        public IEnumerable<Country> OnlyEuropeanUnionCountries(List<Country> countriesList)
        {
            var europeanUnionCountries = countriesList.Where(c => c.independent);

            return europeanUnionCountries;
        }

        public  IEnumerable<Country> SortByPopulation(List<Country> countryList)
        {
            var europeanUnionCountries = OnlyEuropeanUnionCountries(countryList);
            var sortByPopulationTop10 = europeanUnionCountries.OrderByDescending(c => c.population);

            return sortByPopulationTop10;
        }

        public IEnumerable<Country> SortByPopulationDensity(List<Country> countryList)
        {
            var europeanUnionCountries = OnlyEuropeanUnionCountries(countryList);
            
            var sortByPopulationDensityTop10 = europeanUnionCountries.OrderByDescending(c => c.population / c.area);

            return sortByPopulationDensityTop10;
        }

        public IEnumerable FindAllInfoAboutCountry(List<Country> countryList)
        {
            var findInfo = countryList.Select(c => new {
                c.name,
                c.nativeName, 
                c.area, 
                c.population,
                c.topLevelDomain,
                c.independent,
            });

            return findInfo;
        }
    }
}
