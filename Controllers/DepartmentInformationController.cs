using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using _1_Hospital_Managment_Model.Hospital_Managment_Model;
using Hospital_Managment_Web_Api.Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentInformationController : ControllerBase
    {
        [HttpGet]
        public SqlConnection Connect()
        {
            string constr = "data source = DESKTOP-6808B25\\SQLEXPRESS; initial catalog = Db_Hospital_Managment;Integrated Security =True ;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Close();
            sqlcon.Open();
            return sqlcon;
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            SqlConnection sqlcon = Connect();
            string query = "delete m_department_information where department_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetAllData")]
        public ActionResult GetDepartmentData()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_department_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var DeparmentList = new List<Department_Information_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Department_Information_Model d = new Department_Information_Model()
                {

                    department_id = Convert.ToInt32(dt.Rows[i]["department_id"]),
                    department_start_date = Convert.ToDateTime(dt.Rows[i]["department_start_date"]),
                    department_code = Convert.ToString(dt.Rows[i]["department_code"]),
                    department_name = dt.Rows[i]["department_name"].ToString(),
                    deparment_address = dt.Rows[i]["deparment_address"].ToString(),
                    deparment_description = dt.Rows[i]["deparment_description"].ToString(),
                    hospital_id = Convert.ToInt32(dt.Rows[i]["hospital_id"])
                };
                DeparmentList.Add(d);
            }
            return Ok(DeparmentList);
        }
        [HttpPost]
        public async void PostDepartmentData(Department_Information_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            if (model.department_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");

            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");

            }
            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_department_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@department_id", model.department_id);
            sqlcmd.Parameters.AddWithValue("@department_start_date", model.department_start_date);
            sqlcmd.Parameters.AddWithValue("@department_code", model.department_code);
            sqlcmd.Parameters.AddWithValue("@department_name", model.department_name);
            sqlcmd.Parameters.AddWithValue("@deparment_address", model.deparment_address);
            sqlcmd.Parameters.AddWithValue("@deparment_description", model.deparment_description);
            sqlcmd.Parameters.AddWithValue("@hospital_id", model.hospital_id);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {

            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_department_information where department_id="+id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var DeparmentList = new List<Department_Information_Model>();
            Department_Information_Model d = new Department_Information_Model()
            {

                department_id = Convert.ToInt32(dt.Rows[0]["department_id"]),
                department_start_date = Convert.ToDateTime(dt.Rows[0]["department_start_date"]),
                department_code = Convert.ToString(dt.Rows[0]["department_code"]),
                department_name = dt.Rows[0]["department_name"].ToString(),
                deparment_address = dt.Rows[0]["deparment_address"].ToString(),
                deparment_description = dt.Rows[0]["deparment_description"].ToString(),
                hospital_id = Convert.ToInt32(dt.Rows[0]["hospital_id"])
            };
            DeparmentList.Add(d);

            return Ok(DeparmentList);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_department_information where department_name Like '%Department'";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var DeparmentList = new List<Department_Information_Model>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Department_Information_Model d = new Department_Information_Model()
                {

                    department_id = Convert.ToInt32(dt.Rows[i]["department_id"]),
                    department_start_date = Convert.ToDateTime(dt.Rows[i]["department_start_date"]),
                    department_code = Convert.ToString(dt.Rows[i]["department_code"]),
                    department_name = dt.Rows[i]["department_name"].ToString(),
                    deparment_address = dt.Rows[i]["deparment_address"].ToString(),
                    deparment_description = dt.Rows[i]["deparment_description"].ToString(),
                    hospital_id = Convert.ToInt32(dt.Rows[i]["hospital_id"])
                };
                DeparmentList.Add(d);
            }
            return Ok(DeparmentList);
        }
    }
}
