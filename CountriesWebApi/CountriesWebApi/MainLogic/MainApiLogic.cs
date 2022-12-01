using CountriesWebApi.Models;

namespace CountriesWebApi.MainLogic
{
    public class MainApiLogic
    {
        public static IEnumerable<Country> OnlyEuropeanUnionCountries(List<Country> countriesList)
        {
            var europeanUnionCountries = countriesList.Where(c => c.independent);

            return europeanUnionCountries;
        }

        public static IEnumerable<Country> SortByPopulation(List<Country> country)
        {
            var europeanUnionCountries = OnlyEuropeanUnionCountries(country);
            var sortByPopulationTop10 = europeanUnionCountries.OrderByDescending(c => c.population);

            return sortByPopulationTop10;
        }

        public static IEnumerable<Country> SortByPopulationDensity(List<Country> country)
        {
            var europeanUnionCountries = OnlyEuropeanUnionCountries(country);
            var sortByPopulationDensityTop10 = europeanUnionCountries.OrderByDescending(c => c.population / c.area);

            return sortByPopulationDensityTop10;
        }
    }
}
