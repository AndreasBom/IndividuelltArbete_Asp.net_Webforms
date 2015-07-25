using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class TypeOfShift
    {
        //Class representation of table TypeOfShift
        //Not really necessary with validation since it is used in a drop-downlist. 
        
        [Required(ErrorMessage="Fältet får inte vara tomt")]
        public int TOSID { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        [StringLength(6, ErrorMessage="Fältet får innehålla max 6 tecken")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        public int Minutes { get; set; }
    }
}