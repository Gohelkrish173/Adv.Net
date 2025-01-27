using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using CrudWithAjax.Models;

namespace CrudWithAjax.Controllers
{
    public class CountryController : Controller
    {
        private IConfiguration configuration;

        public CountryController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult CountryTable()
        {
            return View("CountryTable");
        }

        public List<CountryModel> CountryData()
        {
            List<CountryModel> list = new List<CountryModel>();
            DataTable row = RetriveTable("PR_LOC_Country_SelectAll");
            foreach(DataRow r in row.Rows)
            {
                list.Add(new CountryModel
                {
                    CountryID = Convert.ToInt32(r["CountryID"]),
                    CountryName = r["CountryName"].ToString(),
                    CountryCode = r["CountryCode"].ToString(),
                    StateCount = Convert.ToInt32(r["StateCount"]),
                });
            }
            return list;
        }

        public DataTable RetriveTable(String SP)
        {
            SqlConnection conn = new SqlConnection(this.configuration.GetConnectionString("myConnection"));
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SP;
            
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();

            return dt;
        }

    }
}
