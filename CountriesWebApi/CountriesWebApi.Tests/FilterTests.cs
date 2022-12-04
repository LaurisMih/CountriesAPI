using CountriesWebApi.Interface;
using CountriesWebApi.Models;
using CountriesWebApi.Filter;
using FluentAssertions;

namespace CountriesWebApi.Tests
{
    [TestClass]
    public class FilterTests
    {
        private readonly List<Country> _testList = new List<Country>()
        {
             new Country
             {
                   Name = "Latvia",
                   NativeName = "Latvija",
                   Area = 64559,
                   Population = 1901548,
                  TopLevelDomain = new List<string>(){".lv"},
                   Independent = true
             },

             new Country
             {
                 Name = "Lithuania",
                 NativeName = "Lietuva",
                 Area = 65300,
                 Population = 2794700,
                 TopLevelDomain = new List<string>(){".lt"},
                 Independent = true
             },

             new Country
             {
                    Name = "Estonia",
                    NativeName = "Eesti",
                    Area = 45227,
                    Population = 1331057,
                    TopLevelDomain = new List<string>(){".ee"},
                    Independent = true
             }
        };

        private ICountryFilter _filter;

        [TestInitialize]
        public void Setup()
        {
            _filter = new CountryFilter();
        }

        [TestMethod]
        public void FilterTests_SortCountriesByPopulation_MustBeEqual()
        {
            //Act
            var filteredList = _filter.GetSortedCountriesByPopulation(_testList);

            //Assert
            var firstCountry = filteredList.First();
            firstCountry.Name.Should().Be("Lithuania");

            var lastCountry = filteredList.Last();
            lastCountry.Name.Should().Be("Estonia");
        }

        [TestMethod]
        public void FilterTests_SortCountriesByPopulationDensity_MustBeEqual()
        {            
            //Act
            var filteredList = _filter.GetSortedCountriesByPopulationDensity(_testList);

            //Assert
            var firstCountry = filteredList.First();
            firstCountry.Name.Should().Be("Lithuania");

            var lastCountry = filteredList.Last();
            lastCountry.Name.Should().Be("Estonia");
        }

        [TestMethod]
        public void FilterTests_GetAllInfoAboutCountryByName_MustBeEqual()
        {
            //Arrange
            var testCountry = new List<Country>()
            {
                new Country
                {
                    Name = "Lithuania",
                    NativeName = "Lietuva",
                    Area = 65300,
                    Population = 2794700,
                    TopLevelDomain = new List<string>(){".lt"},
                    Independent = true
                }
            };
                        
            //Act
            var result = _filter.GetAllInfoAboutCountry(testCountry);

            //Assert          
            result.Should().NotContain("Lithuania");                  
        }
    }
}