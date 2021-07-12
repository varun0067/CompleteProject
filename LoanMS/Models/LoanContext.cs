using Microsoft.EntityFrameworkCore;

namespace LoanMS.Models
{
    public class LoanContext:DbContext
    {
        public LoanContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<EducationLoan> EducationLoans { get; set; }
        public DbSet<PersonalLoan> PersonalLoans { get; set; }
    }
}
