using System.Data.SqlClient;
using System.Web.Mvc;

public class DatabaseController : Controller
{
    public ActionResult CheckConnection()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return Content("Connection successful!");
            }
            catch (SqlException ex)
            {
                return Content($"Connection failed: {ex.Message}");
            }
        }
    }
}