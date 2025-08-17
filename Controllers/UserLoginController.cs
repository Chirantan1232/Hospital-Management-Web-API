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
    public class UserLoginController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetAllData()
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_user_Login_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var UserList = new List<User_Login_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User_Login_Information_Model model = new User_Login_Information_Model()
                {
                    user_id = Convert.ToInt32(dt.Rows[i]["user_id"]),
                    user_name = dt.Rows[i]["user_name"].ToString(),
                    user_password = dt.Rows[i]["user_password"].ToString(),
                    user_confirm_password = dt.Rows[i]["user_confirm_password"].ToString(),
                    Employee_id = Convert.ToInt32(dt.Rows[i]["Employee_id"]),
                    created_by = Convert.ToInt32(dt.Rows[i]["created_by"]),
                    updated_by = Convert.ToInt32(dt.Rows[i]["updated_by"]),


                };
                UserList.Add(model);
            }
            return Ok(UserList);
        }
        [HttpPost]
        public IActionResult PostUserData(User_Login_Information_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_user_Login_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (model.user_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
               
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("flag", "U");
                
            }
            sqlcmd.Parameters.AddWithValue("@user_id", model.user_id);
            sqlcmd.Parameters.AddWithValue("@user_name", model.user_name);
            sqlcmd.Parameters.AddWithValue("@user_password", model.user_password);
            sqlcmd.Parameters.AddWithValue("@user_confirm_password", model.user_confirm_password);
            sqlcmd.Parameters.AddWithValue("@Employee_id", model.Employee_id);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.BeginExecuteNonQuery();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_user_Login_information where user_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
