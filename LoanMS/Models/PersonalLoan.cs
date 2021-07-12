using System;
using System.ComponentModel.DataAnnotations;

namespace LoanMS.Models
{
    public class PersonalLoan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public long Amount { get; set; }
        [Required]
        public DateTime LoanApplyDate { get; set; }
        [Required]
        public DateTime LoanIssueDate { get; set; }
        [Required]
        public int RateOfInterest { get; set; }
        [Required]
        public string DurationOfLoan { get; set; }
        [Required]
        public long AnnualIncome { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int TotalExperience { get; set; }
        [Required]
        public int ExperienceInCurrentCompany { get; set; }
    }
}
