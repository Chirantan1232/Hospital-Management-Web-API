using Hospital_Managment_Web_Api.Connection;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1_Hospital_Managment_Model.Hospital_Managment_Model;
using System.Data.SqlTypes;

namespace Hospital_Managment_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeInfromationController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetAllData()
        {

            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_material_type_infromation";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var MaterialList = new List<Material_Type_Infromation_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Material_Type_Infromation_Model model = new Material_Type_Infromation_Model()
                {
                    material_type_id = Convert.ToInt32(dt.Rows[i]["material_type_id"]),
                    material_type = dt.Rows[i]["material_type"].ToString(),
                    global_id = Convert.ToInt32(dt.Rows[i]["global_id"]),
                    created_by = Convert.ToInt32(dt.Rows[i]["created_by"]),
                    updated_by = Convert.ToInt32(dt.Rows[i]["updated_by"]),


                };
                MaterialList.Add(model);
            }
            return Ok(MaterialList);
        }
        [HttpPost]
        public async void PostMaterialData(Material_Type_Infromation_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_material_type_infromation";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (model.material_type_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
              
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");
               

            }
            sqlcmd.Parameters.AddWithValue("@material_type_id", model.material_type_id);
            sqlcmd.Parameters.AddWithValue("@material_type", model.material_type);
            sqlcmd.Parameters.AddWithValue("@global_id", model.global_id);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ConnectionSql csl = new ConnectionSql();
            string query = "delete m_material_type_infromation where material_type_id=" + id;
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
