using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Person_Information_Model
    {
        public int person_id { get; set; }
        public int client_id { get; set; }
        public int global_id { get; set; }
        public int module_id { get; set; }
        public string person_code { get; set; }
        public int person_type { get; set; }
        public string person_name { get; set; }
        public string person_address { get; set; }
        public string person_email_id { get; set; }
        public string person_contact_number { get; set; }
        public string person_bussness_name { get; set; }
        public string person_office_number { get; set; }
        public string person_pan_card { get; set; }
        public string person_city { get; set; }
        public int person_bank_name { get; set; }
        public string person_account_number { get; set; }
        public string person_gst_number { get; set; }
        public int payment_terms { get; set; }
        public int created_by { get; set; }
        public DateTime created_date { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_date { get; set; }
        public string active_flag { get; set; }
        public string attr1 { get; set; }
        public string attr2 { get; set; }
        public string attr3 { get; set; }
        public int attr4 { get; set; }
        public DateTime attr5 { get; set; }

    }
}
