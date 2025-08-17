using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.Hospital_Managment_Model
{
    public class ErrorLog_Model
    {
        public int errorId {  get; set; }
        public string errorException { get; set; }
        public string errorData { get; set; }
        public string errorLine { get; set; }
        public string errorClassName { get; set; }
        public string errorFunction { get; set; }
        public DateTime errorDate { get; set; }
        public string errorAssignBy { get; set; }
        public string errorTestBy { get; set; }
        public int activeFlag { get; set; }
    }
}
