using System;
using System.ComponentModel.DataAnnotations;

namespace CC2020_API.Models
{
    public class Payslip
    {
        //Agreement Properties
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime WeekBegininning { get; set; }

        [Required]
        public double GrossPay { get; set;}

        [Required]
        public double PayYTD { get; set; }

        [Required]
        public double Tax { get; set; }

        [Required]
        public double BaseHours { get; set; }

        [Required]
        public double SatHours { get; set; }

        [Required]
        public double SunHours { get; set; }

        //Agreement Foreign Keys
        [Required]
        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public long CompanyABN { get; set; }
        public virtual Company Company { get; set; }
    }
}
