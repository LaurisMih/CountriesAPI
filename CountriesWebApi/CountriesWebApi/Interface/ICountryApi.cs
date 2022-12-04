using CountriesWebApi.Models;
using Refit;

namespace CountriesWebApi.Interface
{
    public interface ICountryApi
    {
        [Get("/v2/regionalbloc/eu")]
        Task<List<Country>> GetEuCountries();

       [Get("/v2/name/{name}")]
        Task<List<Country>> GetCountryByName(string name);
    }
}
