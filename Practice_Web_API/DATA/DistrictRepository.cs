
using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;

namespace Practice_Web_API.DATA
{
    public class DistrictRepository
    {
        private readonly IConfiguration _configuration;

        public DistrictRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #region GetAllDistricts
        public IEnumerable<DistrictModel> GetAllDistricts()
        {
            List<DistrictModel> dmodel = new List<DistrictModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnection")))
                {
                    SqlCommand cmd = new SqlCommand("PR_LOC_District_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dmodel.Add(new DistrictModel
                        {
                            StateID = Convert.ToInt32(reader["StateID"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            DistrictID = Convert.ToInt32(reader["DistrictID"]),
                            DistrictName = reader["DistrictName"].ToString()
                        });
                    }

                    return dmodel;
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
