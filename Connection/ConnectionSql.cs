using System.Data.SqlClient;

namespace Hospital_Managment_Web_Api.Connection
{
    public class ConnectionSql
    {
        public SqlConnection Connection()
        {
            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;Timeout=60;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();
            return sqlcon;
        }
    }
}
