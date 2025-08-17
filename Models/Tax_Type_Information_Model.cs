using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public  class Tax_Type_Information_Model
    {
        public int tax_id { get; set; }
        public string tax_name { get; set; }
        public decimal tax_percent { get; set; }
        public int tax_group_id { get; set; }

    }
}
