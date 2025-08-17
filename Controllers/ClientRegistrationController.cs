using System.Data;
using System.Data.SqlClient;
using _1_Hospital_Managment_Model.Hospital_Managment_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRegistrationController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetClientData()
        {
            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();

            string query = "select * from m_client_registration";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Clientlist = new List<Client_Registration_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Client_Registration_Model model = new Client_Registration_Model();
                {
                    model.client_id = Convert.ToInt32(dt.Rows[i]["client_id"]);
                    model.client_code = dt.Rows[i]["client_code"].ToString();
                    model.client_name = Convert.ToString(dt.Rows[i]["client_name"]);
                    model.busniess_name = dt.Rows[i]["busniess_name"].ToString();
                    model.client_phone = dt.Rows[i]["client_phone"].ToString();
                    model.client_email = dt.Rows[i]["client_email"].ToString();
                    model.client_gst = dt.Rows[i]["client_gst"].ToString();
                    model.client_registration_no = dt.Rows[i]["client_registration_no"].ToString();
                    model.client_pan = dt.Rows[i]["client_pan"].ToString();
                    model.user_name = dt.Rows[i]["user_name"].ToString();
                    model.password = dt.Rows[i]["password"].ToString(); 
                    model.client_address = dt.Rows[i]["client_address"].ToString();
                }
                Clientlist.Add(model);
            }
                return Ok(Clientlist);
        }

        [HttpPost]
        public async void ClientPostData(Client_Registration_Model model)
        {

            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();


         
            if (model.client_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
              
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");
                
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "sp_m_client_registration";
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@client_id", model.client_id);
            sqlcmd.Parameters.AddWithValue("@client_code", model.client_code);
            sqlcmd.Parameters.AddWithValue("@client_global_id", model.client_global_id);
            sqlcmd.Parameters.AddWithValue("@client_name", model.client_name);
            sqlcmd.Parameters.AddWithValue("@client_address", model.client_address);
            sqlcmd.Parameters.AddWithValue("@client_phone", model.client_phone);
            sqlcmd.Parameters.AddWithValue("@client_city", "pune");
            sqlcmd.Parameters.AddWithValue("@busniess_name", model.busniess_name);
            sqlcmd.Parameters.AddWithValue("@client_pan", model.client_pan);
            sqlcmd.Parameters.AddWithValue("@client_registration_no", model.client_registration_no);
            sqlcmd.Parameters.AddWithValue("@client_gst", model.client_gst);
            sqlcmd.Parameters.AddWithValue("@client_logo", "logo");
            sqlcmd.Parameters.AddWithValue("@client_email", model.client_email);
            sqlcmd.Parameters.AddWithValue("@password", model.password);
            sqlcmd.Parameters.AddWithValue("@user_name", model.user_name);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@active_flag", model.active_flag);
            sqlcmd.ExecuteNonQuery();
            //return Ok(model);

        }
        [HttpDelete]
        public IActionResult DeleteData(int id)
        {
            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();
            string query = "delete m_client_registration where client_id="+id;
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.ExecuteNonQuery();

            return Ok();
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetData(int id)
        {

            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();

            string query = "select * from m_client_registration where client_id="+id;
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Clientlist = new List<Client_Registration_Model>();
            Client_Registration_Model model = new Client_Registration_Model();
            {
                model.client_id = Convert.ToInt32(dt.Rows[0]["client_id"]);
                model.client_code = dt.Rows[0]["client_code"].ToString();
                model.client_name = Convert.ToString(dt.Rows[0]["client_name"]);
                model.busniess_name = dt.Rows[0]["busniess_name"].ToString();
                model.client_phone = dt.Rows[0]["client_phone"].ToString();
                model.client_email = dt.Rows[0]["client_email"].ToString();
                model.client_gst = dt.Rows[0]["client_gst"].ToString();
                model.client_registration_no = dt.Rows[0]["client_registration_no"].ToString();
                model.client_pan = dt.Rows[0]["client_pan"].ToString();
                model.user_name = dt.Rows[0]["user_name"].ToString();
                model.password = dt.Rows[0]["password"].ToString(); ;
                model.client_address = dt.Rows[0]["client_address"].ToString();
            }
            Clientlist.Add(model);

            return Ok(Clientlist);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();

            //string query = "select * from m_client_registration where client_name Like 'rak%'";
           // string query = "select * from m_client_registration where client_address Like '%pur'";
            string query = "select * from m_client_registration where busniess_name Like '%production'";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Clientlist = new List<Client_Registration_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Client_Registration_Model model = new Client_Registration_Model();
                {
                    model.client_id = Convert.ToInt32(dt.Rows[i]["client_id"]);
                    model.client_code = dt.Rows[i]["client_code"].ToString();
                    model.client_name = Convert.ToString(dt.Rows[i]["client_name"]);
                    model.busniess_name = dt.Rows[i]["busniess_name"].ToString();
                    model.client_phone = dt.Rows[i]["client_phone"].ToString();
                    model.client_email = dt.Rows[i]["client_email"].ToString();
                    model.client_gst = dt.Rows[i]["client_gst"].ToString();
                    model.client_registration_no = dt.Rows[i]["client_registration_no"].ToString();
                    model.client_pan = dt.Rows[i]["client_pan"].ToString();
                    model.user_name = dt.Rows[i]["user_name"].ToString();
                    model.password = dt.Rows[i]["password"].ToString(); ;
                    model.client_address = dt.Rows[i]["client_address"].ToString();
                }
                Clientlist.Add(model);
            }
            return Ok(Clientlist);
        }
    }
}
