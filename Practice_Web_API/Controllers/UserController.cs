using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Web_API.BAL;
using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly User_BALbase u_BALbase;

        public UserController(User_BALbase _u_BALbase)
        {
            u_BALbase = _u_BALbase;
        }

        #region GetAllUsers
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            List<UserModel> umodel = u_BALbase.GetAllUsers();
            Dictionary<String,dynamic> responce = new Dictionary<String,dynamic>();
            if (umodel.Count > 0 && umodel != null)
            {
                responce.Add("Status", true);
                responce.Add("Message", "Data Retrieve Successfully");
                responce.Add("Data", umodel);
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
        #endregion
    }
}
