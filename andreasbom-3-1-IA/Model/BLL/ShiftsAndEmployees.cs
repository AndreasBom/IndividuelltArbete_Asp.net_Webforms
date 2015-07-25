using System;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class ShiftsAndEmployees
    {
        //Read-only from database -> no validation needed

            public int ShiftID { get; set; }
            public int EmpID { get; set; }
            public string EmpCode { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Date { get; set; }
            public int TOSID { get; set; }
            public string Description { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public int Minutes { get; set; }
    }
}