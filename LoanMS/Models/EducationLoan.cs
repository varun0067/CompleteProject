using System;
using System.ComponentModel.DataAnnotations;

namespace LoanMS.Models
{
    public class EducationLoan
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
        public long CourseFee { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string FatherOccupation { get; set; }
        [Required]
        public int FatherTotalExperience { get; set; }
        [Required]
        public int FatherExperienceInCurrentCompany { get; set; }
        [Required]
        public long RationCardNumber { get; set; }
        [Required]
        public long AnnualIncome { get; set; }
    }
}
