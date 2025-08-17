using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Department_Information_Model
    {
        public long department_id { get; set; }
        public DateTime department_start_date { get; set; }
       public string department_code { get; set; }
        public string department_name { get; set; }
        public string deparment_address { get; set; }
       public string deparment_description { get; set; }
        public int hospital_id { get; set; }
       public int created_by { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
       public int updated_by { get; set; }

    }
}
