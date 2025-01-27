
using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class Country_BALbase
    {
        private readonly CountryRepository _countryRepository;

        public Country_BALbase(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        #region GetAllCountries
        public List<CountryModel> GetAllCities()
        {
            try
            {
                List<CountryModel> countrymodel = _countryRepository.GetAllCountries().ToList();
                if (countrymodel != null) 
                { 
                    return countrymodel;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
