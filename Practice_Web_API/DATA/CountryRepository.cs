
using Microsoft.Data.SqlClient;
using Practice_Web_API.Models;
using System.Runtime.CompilerServices;

namespace Practice_Web_API.DATA
{
    public class CountryRepository
    {
        private readonly IConfiguration _configuration;

        public CountryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        #region GetAllCountries
        public IEnumerable<CountryModel> GetAllCountries()
        {
            try
            {
                List<CountryModel> countries = new List<CountryModel>();
                using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnection")))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PR_LOC_Country_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        countries.Add(new CountryModel
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CountryName = reader["CountryName"].ToString(),
                            CountryID = Convert.ToInt32(reader["CountryID"])
                        });
                    }
                    return countries;
                }
            }
            catch
            {
                return [];
            }
        }
        #endregion

    }
}
