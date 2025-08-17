using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Hospital_Information_Model
    {
        public int hospital_id { get; set; }
        public string hospital_name { get; set; }
        public string hospital_address { get; set; }
        public string hospital_email_address { get; set; }
        public string logo { get; set; }
        public string hospital_city { get; set; }
        public string hospital_pan { get; set; }
        public string hospital_gst_number { get; set; }
        public string hospital_contact_number { get; set; }
        public string hospital_contact_number1 { get; set; }
        public string hospital_web_site { get; set; }
        public int created_by { get; set; }
        public DateTime created_date { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_date { get; set; }

    }
}
