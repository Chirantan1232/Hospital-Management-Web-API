using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Unit_Information_Model
    {
        public int unit_id { get; set; }
        public string Unit_name { get; set; }
        public DateTime created_date { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_date { get; set; }

    }
}
