using System.Data;
using System.Data.SqlClient;
using _1_Hospital_Managment_Model.Hospital_Managment_Model;
using Hospital_Managment_Web_Api.Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalInformationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHospitalData()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_hospital_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var HospitaltList = new List<Hospital_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Hospital_Information_Model model = new Hospital_Information_Model()
                {
                    hospital_id = Convert.ToInt32(dt.Rows[i]["hospital_id"]),
                    hospital_name = Convert.ToString(dt.Rows[i]["hospital_name"]),
                    hospital_address = dt.Rows[i]["hospital_address"].ToString(),
                    hospital_email_address = dt.Rows[i]["hospital_email_address"].ToString(),
                    hospital_city = dt.Rows[i]["hospital_city"].ToString(),
                    hospital_pan = dt.Rows[i]["hospital_pan"].ToString(),
                    hospital_gst_number = dt.Rows[i]["hospital_gst_number"].ToString(),
                    hospital_contact_number = dt.Rows[i]["hospital_contact_number"].ToString(),
                    hospital_contact_number1 = dt.Rows[i]["hospital_contact_number1"].ToString(),
                    hospital_web_site = dt.Rows[i]["hospital_web_site"].ToString(),



                };
                HospitaltList.Add(model);
            }
            return Ok(HospitaltList);
        }
        [HttpPost]
        public async void PostHospitalData(Hospital_Information_Model model)
        {

            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_hospital_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (model.hospital_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
             
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");
            
            }
            sqlcmd.Parameters.AddWithValue("@hospital_id", model.hospital_id);
            sqlcmd.Parameters.AddWithValue("@hospital_name", model.hospital_name);
            sqlcmd.Parameters.AddWithValue("@hospital_address", model.hospital_address);
            sqlcmd.Parameters.AddWithValue("@hospital_email_address", model.hospital_email_address);
            sqlcmd.Parameters.AddWithValue("@logo", "");
            sqlcmd.Parameters.AddWithValue("@hospital_city", model.hospital_city);
            sqlcmd.Parameters.AddWithValue("@hospital_pan", model.hospital_pan);
            sqlcmd.Parameters.AddWithValue("@hospital_gst_number", model.hospital_gst_number);
            sqlcmd.Parameters.AddWithValue("@hospital_contact_number", model.hospital_contact_number);
            sqlcmd.Parameters.AddWithValue("@hospital_contact_number1", model.hospital_contact_number1);
            sqlcmd.Parameters.AddWithValue("@hospital_web_site", model.hospital_web_site);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_hospital_information where hospital_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
