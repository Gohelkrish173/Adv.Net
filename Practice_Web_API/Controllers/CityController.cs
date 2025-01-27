using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.BAL;
using Practice_Web_API.Models;
using System.Runtime.InteropServices;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly City_BALbase _cityBALbase;

        public CityController(City_BALbase cityBALbase)
        {
            _cityBALbase = cityBALbase;
        }

        #region GetAllCities
        [HttpGet]
        public IActionResult GetAllCities()
        {
            try
            {
                List<CityModel> citymodel = _cityBALbase.GetAllCities();
                Dictionary<String, dynamic> responce = new Dictionary<String, dynamic>();
                if (citymodel != null)
                {
                    responce.Add("Status", true);
                    responce.Add("Message", "Data Retrieve Successfully.");
                    responce.Add("Data", citymodel);
                    return Ok(responce);
                }
                else
                {
                    responce.Add("Status", false);
                    responce.Add("Message", "Data Not Retrieve.");
                    responce.Add("Data", null);
                    return Ok(responce);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            #endregion
        }
    }
}
