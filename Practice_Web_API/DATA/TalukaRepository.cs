using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;

namespace Practice_Web_API.DATA
{
    public class TalukaRepository
    {
        private readonly IConfiguration _configuration;

        public TalukaRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        #region GetAllTalukas
        public IEnumerable<TalukaModel> GetAllTalukas()
        {
            List<TalukaModel> talukamodel = new List<TalukaModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnection")))
                {
                    SqlCommand cmd = new SqlCommand("PR_LOC_Taluka_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        talukamodel.Add(new TalukaModel
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            DistrictID = Convert.ToInt32(reader["DistrictID"]),
                            TalukaName = reader["TalukaName"].ToString(),
                            TalukaID = Convert.ToInt32(reader["TalukaID"]),
                        });
                    }

                    return talukamodel;
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
