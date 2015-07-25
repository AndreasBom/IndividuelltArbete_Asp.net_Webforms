using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class TimeReport
    {
        //Read-only from database -> no validation needed

        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Total { get; set; }

    }
}