using Hospital_Managment_Web_Api.Connection;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1_Hospital_Managment_Model.Hospital_Managment_Model;

namespace Hospital_Managment_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInformationController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetAllData()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_person_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var PersonList = new List<Person_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Person_Information_Model m = new Person_Information_Model()
                {
                    person_id = Convert.ToInt32(dt.Rows[i]["person_id"]),
                    client_id = Convert.ToInt32(dt.Rows[i]["client_id"]),
                    global_id = Convert.ToInt32(dt.Rows[i]["global_id"]),
                    module_id = Convert.ToInt32(dt.Rows[i]["module_id"]),
                    person_code = dt.Rows[i]["person_code"].ToString(),
                    person_type = Convert.ToInt32(dt.Rows[i]["person_type"]),
                    person_name = dt.Rows[i]["person_name"].ToString(),
                    person_address = dt.Rows[i]["person_address"].ToString(),
                    person_email_id = dt.Rows[i]["person_email_id"].ToString(),
                    person_contact_number = dt.Rows[i]["person_contact_number"].ToString(),
                    person_bussness_name = dt.Rows[i]["person_bussness_name"].ToString(),
                    person_office_number = dt.Rows[i]["person_office_number"].ToString(),
                    person_pan_card = dt.Rows[i]["person_pan_card"].ToString(),
                    person_city = dt.Rows[i]["person_city"].ToString(),
                    person_bank_name = Convert.ToInt32(dt.Rows[i]["person_bank_name"]),
                    person_account_number = dt.Rows[i]["person_account_number"].ToString(),
                    person_gst_number = dt.Rows[i]["person_gst_number"].ToString(),

                };
                PersonList.Add(m);
            }
            return Ok(PersonList);
        }
        [HttpPost]
        public async void PostPersonData(Person_Information_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_person_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (model.person_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
               
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("flag", "U");
              
            }

            sqlcmd.Parameters.AddWithValue("@person_id", model.person_id);
            sqlcmd.Parameters.AddWithValue("@client_id", model.client_id);
            sqlcmd.Parameters.AddWithValue("@global_id", model.global_id);
            sqlcmd.Parameters.AddWithValue("@module_id", model.module_id);
            sqlcmd.Parameters.AddWithValue("@person_code", model.person_code);
            sqlcmd.Parameters.AddWithValue("@person_type", model.person_type);
            sqlcmd.Parameters.AddWithValue("@person_name", model.person_name);
            sqlcmd.Parameters.AddWithValue("@person_address", model.person_address);
            sqlcmd.Parameters.AddWithValue("@person_email_id", model.person_email_id);
            sqlcmd.Parameters.AddWithValue("@person_contact_number", model.person_contact_number);
            sqlcmd.Parameters.AddWithValue("@person_bussness_name", model.person_bussness_name);
            sqlcmd.Parameters.AddWithValue("@person_office_number", model.person_office_number);
            sqlcmd.Parameters.AddWithValue("@person_pan_card", model.person_pan_card);
            sqlcmd.Parameters.AddWithValue("@person_city", model.person_city);
            sqlcmd.Parameters.AddWithValue("@person_bank_name", model.person_bank_name);
            sqlcmd.Parameters.AddWithValue("@person_account_number", model.person_account_number);
            sqlcmd.Parameters.AddWithValue("@person_gst_number", model.person_gst_number);
            sqlcmd.Parameters.AddWithValue("@payment_terms", model.payment_terms);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@active_flag", "");
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_person_information where person_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
