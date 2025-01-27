using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;

namespace Practice_Web_API.DATA
{
    public class CityRepository
    {
        private readonly IConfiguration _configuration;

        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllCities
        public IEnumerable<CityModel> GetAllCities()
        {
            List<CityModel> citymodel = new List<CityModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnection")))
                {
                    SqlCommand cmd = new SqlCommand("PR_LOC_City_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        citymodel.Add(new CityModel
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            TalukaID = Convert.ToInt32(reader["TalukaID"]),
                            CityID = Convert.ToInt32(reader["CityID"]),
                            CityName = reader["CityName"].ToString()
                        });
                    }

                    return citymodel;
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
