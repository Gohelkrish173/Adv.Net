using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;

namespace Practice_Web_API.DATA
{
    public class StateRepository
    {
        private readonly IConfiguration _configuration;

        public StateRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #region GetAllStates
        public IEnumerable<StateModel> GetAllStates()
        {
            List<StateModel> smodel = new List<StateModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnection")))
                {
                    SqlCommand cmd = new SqlCommand("PR_LOC_State_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        smodel.Add(new StateModel
                        {
                            StateID = Convert.ToInt32(reader["StateID"]),
                            StateName = reader["StateName"].ToString(),
                            CountryID = Convert.ToInt32(reader["CountryID"]),
                            UserID = Convert.ToInt32(reader["UserID"])
                        });
                    }

                    return smodel;
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
