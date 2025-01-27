using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.BAL;
using Practice_Web_API.Models;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly State_BALbase state_BALbase;

        public StateController(State_BALbase state_BALbase)
        {
            this.state_BALbase = state_BALbase;
        }

        #region GetAllStates
        [HttpGet]
        public IActionResult GetAllStates()
        {
            List<StateModel> states = state_BALbase.GetAllStates();
            Dictionary<String, dynamic> responce = new Dictionary<String, dynamic>();
            if (states != null) 
            {
                responce.Add("Status", true);
                responce.Add("Message","Data Retrieve Successfully");
                responce.Add("Data", states);
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
        #endregion
    }
}
