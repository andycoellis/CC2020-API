using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC2020_API.Models
{
    public class Company
    {
        //Company Properties
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1e10, (1e11 - 1))]
        public long ABN { get; set; }

        [Required]
        [MaxLength(40), RegularExpression(@"^[^\s][A-Za-z\s]+[^\s]$")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^\b[\dA-Za-z\s\-\,\\]+\b$")]
        public string Address { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Company Associations
        public virtual ICollection<PayAgreement> PayAgreements { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
        public virtual ICollection<Payslip> Payslips { get; set; }
    }
}
