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
    public class ItemInformationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllData()
        {

            ConnectionSql csl = new ConnectionSql();
            string query = "select * from m_item_information";
            SqlCommand sqlcmd = new SqlCommand(query, csl.Connection());
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var ItemList = new List<Item_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item_Information_Model model = new Item_Information_Model()
                {
                    item_id = Convert.ToInt32(dt.Rows[i]["item_id"]),
                    item_code = Convert.ToString(dt.Rows[i]["item_code"]),
                    item_type = Convert.ToInt32(dt.Rows[i]["item_type"]),
                    item_name = dt.Rows[i]["item_name"].ToString(),
                    item_manufaction_name = dt.Rows[i]["item_manufaction_name"].ToString(),
                    item_pacinking = Convert.ToInt32(dt.Rows[i]["item_pacinking"]),
                    item_use_name = dt.Rows[i]["item_use_name"].ToString(),
                    item_description = dt.Rows[i]["item_description"].ToString(),
                    item_start_date = Convert.ToDateTime(dt.Rows[i]["item_start_date"]),
                    item_end_date = Convert.ToDateTime(dt.Rows[i]["item_end_date"]),
                    item_first_unit = Convert.ToInt32(dt.Rows[i]["item_first_unit"]),
                    item_second_unit = Convert.ToInt32(dt.Rows[i]["item_second_unit"]),
                    item_conversion_first_factor = Convert.ToInt32(dt.Rows[i]["item_conversion_first_factor"]),
                    item_conversion_second_factor = Convert.ToInt32(dt.Rows[i]["item_conversion_second_factor"]),
                    //item_is_stockebal = Convert.(dt.Rows[i]["item_is_stockebal"]),
                    //item_conversion_second_factor = Convert.ToInt32(dt.Rows[i]["item_conversion_second_factor"]),


                };
                ItemList.Add(model);
            }
            return Ok(ItemList);
        }

        [HttpPost]
        public async void PostItemData(Item_Information_Model model)
        {
            ConnectionSql csl = new ConnectionSql();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.Connection = csl.Connection();
            sqlcmd.CommandText = "sp_m_item_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (model.item_id == 0)
            {
                sqlcmd.Parameters.AddWithValue("flag", "I");
                
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("flag", "U");
               

            }
            sqlcmd.Parameters.AddWithValue("@item_id", model.item_id);
            sqlcmd.Parameters.AddWithValue("@item_code", model.item_code);
            sqlcmd.Parameters.AddWithValue("@item_type", model.item_type);
            sqlcmd.Parameters.AddWithValue("@item_name", model.item_name);
            sqlcmd.Parameters.AddWithValue("@item_manufaction_name", model.item_manufaction_name);
            sqlcmd.Parameters.AddWithValue("@item_pacinking", model.item_pacinking);
            sqlcmd.Parameters.AddWithValue("@item_use_name", model.item_use_name);
            sqlcmd.Parameters.AddWithValue("@item_description", model.item_description);
            sqlcmd.Parameters.AddWithValue("@item_start_date", model.item_start_date);
            sqlcmd.Parameters.AddWithValue("@item_end_date", model.item_end_date);
            sqlcmd.Parameters.AddWithValue("@item_first_unit", model.item_first_unit);
            sqlcmd.Parameters.AddWithValue("@item_second_unit", model.item_second_unit);
            sqlcmd.Parameters.AddWithValue("@item_conversion_first_factor", model.item_conversion_first_factor);
            sqlcmd.Parameters.AddWithValue("@item_conversion_second_factor", model.item_conversion_second_factor);
            sqlcmd.Parameters.AddWithValue("@item_is_stockebal", model.item_is_stockebal);
            sqlcmd.Parameters.AddWithValue("@item_quality_check", model.item_quality_check);
            sqlcmd.Parameters.AddWithValue("@item_return_policy", model.item_return_policy);
            sqlcmd.Parameters.AddWithValue("@item_min_qty", model.item_min_qty);
            sqlcmd.Parameters.AddWithValue("@item_max_qty", model.item_max_qty);
            sqlcmd.Parameters.AddWithValue("@item_hsn_code", model.item_hsn_code);
            sqlcmd.Parameters.AddWithValue("@item_po_type", model.item_po_type);
            sqlcmd.Parameters.AddWithValue("@item_tax_apply", model.item_tax_apply);
            sqlcmd.Parameters.AddWithValue("@item_po_tax_group", model.item_po_tax_group);
            sqlcmd.Parameters.AddWithValue("@item_sale_tax_group", model.item_sale_tax_group);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@activ_flag", model.activ_flag);
            sqlcmd.ExecuteNonQuery();
            //return Ok();
        }
    }
}
