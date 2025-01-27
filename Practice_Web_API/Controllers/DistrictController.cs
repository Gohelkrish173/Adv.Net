using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.BAL;
using Practice_Web_API.Models;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly District_BALbase districtBALbase;

        public DistrictController(District_BALbase districtBALbase)
        {
            this.districtBALbase = districtBALbase;
        }

        #region GetAllDistrict
        [HttpGet]
        public IActionResult GetAllDistrict()
        {
            try
            {
                List<DistrictModel> districts = districtBALbase.GetAllDistricts();
                Dictionary<String, dynamic> responce = new Dictionary<String, dynamic>();
                if (districts != null)
                {
                    responce.Add("Status", true);
                    responce.Add("Message", "Data Retrieve Successfully");
                    responce.Add("Data", districts);
                    return Ok(responce);
                }
                else
                {
                    responce.Add("Status", false);
                    responce.Add("Message", "Data Retrieve Successfully");
                    responce.Add("Data", null);
                    return Ok(responce);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
