using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.BAL;
using Practice_Web_API.Models;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalukaController : ControllerBase
    {
        private readonly Taluka_BALbase talukaBALbase;

        public TalukaController(Taluka_BALbase talukaBALbase)
        {
            this.talukaBALbase = talukaBALbase;
        }

        #region GetAllDistrict
        [HttpGet]
        public IActionResult GetAllTalukas()
        {
            try
            {
                List<TalukaModel> talukas = talukaBALbase.GetAllTalukas();
                Dictionary<String, dynamic> responce = new Dictionary<String, dynamic>();
                if (talukas != null)
                {
                    responce.Add("Status", true);
                    responce.Add("Message", "Data Retrieve Successfully");
                    responce.Add("Data", talukas);
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
