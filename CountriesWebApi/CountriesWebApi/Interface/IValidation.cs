using CountriesWebApi.Models;

namespace CountriesWebApi.Interface
{
    public interface IValidation
    {
        public bool isValidRegion(List<Country> countriesList, Country country);
    }
}
