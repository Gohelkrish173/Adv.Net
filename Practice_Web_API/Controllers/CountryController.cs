using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Practice_Web_API.BAL;
using Practice_Web_API.Models;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly Country_BALbase _country;

        public CountryController(Country_BALbase country)
        {
            _country = country;
        }

        #region GetAllCountries
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            try
            {
                List<CountryModel> countryModels = _country.GetAllCities();
                Dictionary<String, dynamic> responce = new Dictionary<String, dynamic>();
                if (countryModels != null && countryModels.Count > 0)
                {
                    responce.Add("Status", true);
                    responce.Add("Message", "Data Retrieve Successfully");
                    responce.Add("Data", countryModels);
                    return Ok(responce);
                }
                else
                {
                    responce.Add("Status", false);
                    responce.Add("Message", "Data Not Retrieved.");
                    responce.Add("Data", null);
                    return Ok(responce);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
