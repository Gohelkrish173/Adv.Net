using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;

namespace Practice_Web_API.DATA
{
    public class UserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #region GetAllUsers
        public IEnumerable<UserModel> GetAllUsers()
        {
            try
            {
                List<UserModel> umodel = new List<UserModel>();
                using (SqlConnection conn = new SqlConnection(this.configuration.GetConnectionString("myConnection")))
                {
                    SqlCommand cmd = new SqlCommand("PR_LOC_User_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        umodel.Add(new UserModel
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                            Mobile = reader["Mobile"].ToString()
                        });
                    }
                    return umodel;
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
