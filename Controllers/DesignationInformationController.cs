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
    public class DesignationInformationController : ControllerBase
    {
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_designation_information where designation_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query,csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByNames()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * FROM m_designation_information where designation_name Like '%Manager%'";
            //string query = "select * FROM m_designation_information where designation_name Like 'Nurse%'";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Designationlist = new List<Designation_Information_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Designation_Information_Model model = new Designation_Information_Model()
                {

                    designation_id = Convert.ToInt32(dt.Rows[i]["designation_id"]),
                    designation_code = Convert.ToInt32(dt.Rows[i]["designation_code"]),
                    designation_name = Convert.ToString(dt.Rows[i]["designation_name"]),
                };
                Designationlist.Add(model);
            }
            return Ok(Designationlist);
        }
        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetDesignationData()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_designation_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Designationlist = new List<Designation_Information_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Designation_Information_Model model = new Designation_Information_Model()
                {
                    designation_id = Convert.ToInt32(dt.Rows[i]["designation_id"]),
                    designation_code = Convert.ToInt32(dt.Rows[i]["designation_code"]),
                    designation_name = Convert.ToString(dt.Rows[i]["designation_name"]),
                    designation_qualification = dt.Rows[i]["designation_qualification"].ToString(),
                    designation_description = dt.Rows[i]["designation_description"].ToString(),
                };
                Designationlist.Add(model);
            }
            return Ok(Designationlist);
        }
        [HttpPost]
        public async void PostDesignationData(Designation_Information_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            if (model.designation_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");

            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");

            }
            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_designation_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@designation_id", model.designation_id);
            sqlcmd.Parameters.AddWithValue("@designation_code", model.designation_code);
            sqlcmd.Parameters.AddWithValue("@designation_name", model.designation_name);
            sqlcmd.Parameters.AddWithValue("@designation_qualification", model.designation_qualification);
            sqlcmd.Parameters.AddWithValue("@designation_description", model.designation_description);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@ac_flag", model.ac_flag);
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {

            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_designation_information where designation_id="+id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Designationlist = new List<Designation_Information_Model>();
            Designation_Information_Model model = new Designation_Information_Model()
            {
                designation_id = Convert.ToInt32(dt.Rows[0]["designation_id"]),
                designation_code = Convert.ToInt32(dt.Rows[0]["designation_code"]),
                designation_name = Convert.ToString(dt.Rows[0]["designation_name"]),
                designation_qualification = dt.Rows[0]["designation_qualification"].ToString(),
                designation_description = dt.Rows[0]["designation_description"].ToString(),
            };
            Designationlist.Add(model);

            return Ok(Designationlist);
        }
    }
}
