using CountriesWebApi.Interface;
using CountriesWebApi.Models;
using CountriesWebApi.Validation;

namespace CountriesWebApi.Tests
{
    [TestClass]
    public class CountryValidationTests
    {
        private ICountryValidation _validation;

        private readonly List<Country> _testList = new List<Country>()
        {
             new Country
             {
                   Name = "Latvia"             
             },          
        };

        [TestInitialize]
        public void Setup()
        {
            _validation = new CountryValidation();
          
        }

        [TestMethod]
        public void NameValidation_LatviaIsEuCountry_ShouldReturnTrue()
        {
            //Arrange
            var testCountry = new Country
            {
                Name = "Latvia"
            };

            //Act
            var result = _validation.CountryIsValid(_testList, testCountry);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NameValidation_NorwayIsNotEuCountry_ShouldReturnFalse()
        {
            //Arrange
            var testCountry = new Country
            {
                Name = "Norway"
            };

            //Act
            var result = _validation.CountryIsValid(_testList, testCountry);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
