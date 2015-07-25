using System.ComponentModel.DataAnnotations;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class Employee
    {
        //Class representation of table Employee//
        
        
        public int EmpID { get; set; }
        
        [StringLength(6, ErrorMessage="Anställningsnummret kan max innehålla 6 tecken.")]
        public string EmpCode { get; set; }
        
        [Required(ErrorMessage = "Ett förnamn måste anges")]
        [StringLength(20, ErrorMessage = "Förnamnet kan max innehålla 20 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett Efternamn måste anges")]
        [StringLength(20, ErrorMessage = "Efternamnet kan max innehålla 20 tecken.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Ett personnummer måste anges")]
        [RegularExpression(@"^[1-9]\d{5}-\d{4}", ErrorMessage="Fyll i personnummret med formatet 810101-2222.")]
        public string BirthNo { get; set; }
        
        [Required(ErrorMessage = "En gatuadress måste anges")]
        [StringLength(25, ErrorMessage = "Gatuadressen kan max innehålla 25 tecken.")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "En gatuadress måste anges")]
        [RegularExpression(@"^[1-9]\d{2} ?\d{2}", ErrorMessage = "Postnumret ska innehålla 5 siffror")]
        public string PostNo { get; set; }

        [Required(ErrorMessage = "En gatuadress måste anges")]
        [StringLength(20, ErrorMessage = "Ortsnamnet kan max innehålla 20 tecken.")]
        public string City { get; set; }

        
        [StringLength(15, ErrorMessage = "Telefonnummret kan max innehålla 15 tecken.")]
        public string PhoneNo { get; set; }

    }
}