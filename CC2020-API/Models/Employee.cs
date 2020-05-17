using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CC2020_API.Models
{
    public class Employee : IdentityUser
    {
        public Employee() : base() { }

        [MaxLength(40), RegularExpression(@"^[^\s][A-Za-z\s]+[^\s]$")]
        public string Name { get; set; }

        //Identification Purposes Only
        [StringLength(9), RegularExpression(@"^[\d]+$", ErrorMessage = "An Individual TFN can only be 9 digits long")]
        [Display(Name = "Tax File Number")]
        public string TFN { get; set; }

        [MaxLength(50), RegularExpression(@"^\b[\dA-Za-z\s\-\\]+\b$", ErrorMessage = "Only letters and numbers")]
        public string Address { get; set; }

        [MaxLength(40), RegularExpression(@"^\b[A-Za-z\s]+$", ErrorMessage = "Please only use names.")]
        public string City { get; set; }

        //Must be 3 lettered Australian state, WA, NT???
        [MaxLength(3)]
        [RegularExpression(@"(?i)\b(vic|qld|sa|act|nsw|wa|tas|nt|)\b", ErrorMessage = "Abbreviated names only")]
        public string State { get; set; }

        //Must be a 4 digit number
        [RegularExpression(@"\b\d{4}\b", ErrorMessage = "Four digits only")]
        public string PostCode { get; set; }



        //Associated Models
        public virtual ICollection<Timesheet> Timesheets { get; set; }
        public virtual ICollection<PayAgreement> PayAgreements { get; set; }
        public virtual ICollection<Payslip> Payslips { get; set; }
    }
}
