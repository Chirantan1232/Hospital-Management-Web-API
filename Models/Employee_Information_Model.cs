using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Employee_Information_Model
    {
       public int employee_id { get; set; }
       public string employee_code { get; set; }
       public int employee_title { get; set; }
       public int employee_gender { get; set; }
       public string employee_name { get; set; }
        public int employye_designation { get; set; }
        public int employee_department { get; set; }
        public DateTime employee_dob { get; set; }
        public DateTime employee_joing_date { get; set; }
        public string employee_Address { get; set; }
        public string employee_Address1 { get; set; }
        public string employee_city { get; set; }
        public string employee_pan { get; set; }
        public string employee_adharchard { get; set; }
        public string employee_alternet_no { get; set; }
        public string employee_mobile { get; set; }
        public string employee_email_id { get; set; }
        public int employee_bank_name { get; set; }
        public string employee_account_no { get; set; }
        public string employee_ifsc_code { get; set; }
        public int employee_branch { get; set; }
        public string employee_photo { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public bool active_flag { get; set; }
        public string attr1 { get; set; }
        public string attr2 { get; set; }
        public string attr3 { get; set; }
        public int attr4 { get; set; }

    }
}
