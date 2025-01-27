using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class City_BALbase
    {
        private readonly CityRepository _cityRepository;

        public City_BALbase(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        #region GetAllCities
        public List<CityModel> GetAllCities()
        {
            try
            {
                List<CityModel> cities = _cityRepository.GetAllCities().ToList();
                if (cities != null && cities.Count > 0) 
                {
                    return cities;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
        #endregion
    }
}
