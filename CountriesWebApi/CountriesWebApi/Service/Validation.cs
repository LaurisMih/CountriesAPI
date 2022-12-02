using CountriesWebApi.Interface;
using CountriesWebApi.Models;

namespace CountriesWebApi.Service
{
    public class Validation : IValidation
    {
        public bool isValidRegion(List<Country> countriesList, Country country)
        {
            if (countriesList.Any(c => c.name != country.name))
            {
                return false;
            }
            return true;
        }
    }
}
