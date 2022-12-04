using CountriesWebApi.Interface;
using CountriesWebApi.Models;

namespace CountriesWebApi.Validation
{
    public class CountryValidation : ICountryValidation
    {
        
        public bool CountryIsValid(List<Country> countriesList, Country country)
        {          
            
            if (countriesList.Any(c => c.Name == country.Name))
            {
                return true;
            }

            return false;
        }
    }
}
