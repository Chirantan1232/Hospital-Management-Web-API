using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class Client_Registration_Model
    {
       public int client_id {  get; set; }
         public string client_code {  get; set; }
          public int client_global_id { get; set; } 

            public string client_name {  get; set; }
            public string client_address {  get; set; }
           public string client_phone {  get; set; } 
           public string client_city {  get; set; }
            public string busniess_name {  get; set; }
           public string client_pan { get; set; }

           public string client_registration_no { get; set; }

            public string client_gst { get; set; }

        public string client_logo { get; set; }

        public string client_email { get; set; }
          public string password { get; set; }
        public string user_name { get; set; }
         public int  created_by { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
       public string active_flag { get; set; }
        public string attr1 { get; set; }
        public string attr2 { get; set; }
        public int attr3 { get; set; }
    }
}
