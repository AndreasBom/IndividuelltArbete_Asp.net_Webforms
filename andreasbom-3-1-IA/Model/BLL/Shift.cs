using System;
using System.ComponentModel.DataAnnotations;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class Shift
    {
        //Class representation of table Shift
        public int ShiftID { get; set; }

        [Required(ErrorMessage="Datum måste anges")]
        [RegularExpression(@"^(19|20)\d\d([-])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01]) [0]\d:[0]\d:[0]\d$", ErrorMessage = "Skriv in ett datum med formatet 2015-01-01")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage="Personal måste anges")]
        public int EmpID { get; set; }

        [Required(ErrorMessage="Typ av skift måste anges")]
        public int TOSID { get; set; }
        
        //Not in use
        public bool IsAbsID { get; set; }

    }
}