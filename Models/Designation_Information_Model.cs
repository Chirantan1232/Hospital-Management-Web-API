using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Designation_Information_Model
    {
        public int designation_id { get; set; }
        public int designation_code { get; set; }
        public string designation_name { get; set; }
        public string designation_qualification { get; set; }
        public string designation_description { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
       public int  ac_flag { get; set; }

    }
}
