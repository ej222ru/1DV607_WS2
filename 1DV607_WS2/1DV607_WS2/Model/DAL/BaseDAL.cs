using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace _1DV607_WS2.Model.DAL
{

    public abstract class BaseDAL
    {
        private static string _connectionString;

        static BaseDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
        }
        protected SqlConnection CreateConnection()
        {
            // Skapar och initierar ett anslutningsobjekt.
            return  new SqlConnection(_connectionString);
        }
    }
}
