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
    public class PackingController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllData()
        {

            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_packing";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var PackinglList = new List<Packing_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Packing_Model model = new Packing_Model()
                {
                    packing_id = Convert.ToInt32(dt.Rows[i]["packing_id"]),
                    packing_name = dt.Rows[i]["packing_name"].ToString(),
                    first_packing_convert = Convert.ToInt32(dt.Rows[i]["first_packing_convert"]),
                    second_packing_convert = Convert.ToInt32(dt.Rows[i]["second_packing_convert"]),


                };
                PackinglList.Add(model);
            }
            return Ok(PackinglList);    
        }
        [HttpPost]
        public IActionResult PostPackingData(Packing_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();


            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_packing";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (model.packing_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
               
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");
               

            }
            sqlcmd.Parameters.AddWithValue("@packing_id", model.packing_id);
            sqlcmd.Parameters.AddWithValue("@packing_name", model.packing_name);
            sqlcmd.Parameters.AddWithValue("@first_packing_convert", model.first_packing_convert);
            sqlcmd.Parameters.AddWithValue("@second_packing_convert", model.second_packing_convert);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_packing where packing_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
