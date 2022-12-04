using CountriesWebApi.Models;

namespace CountriesWebApi.Interface
{
    public interface ICountryValidation
    {
        public bool CountryIsValid(List<Country> countriesList, Country country);
    }
}
