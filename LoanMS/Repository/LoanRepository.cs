using LoanMS.Interface;
using LoanMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMS.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanContext _context;

        public LoanRepository(LoanContext context)
        {
            _context = context;
        }

        public async Task AddEducationLoan(EducationLoan educationLoan)
        {
            await _context.EducationLoans.AddAsync(educationLoan);
            _context.SaveChanges(); 
        }

        public async Task AddPersonalLoan(PersonalLoan personalLoan)
        {  
            await _context.PersonalLoans.AddAsync(personalLoan);
            _context.SaveChanges();
        }

        public async Task<List<EducationLoan>> GetEducationLoans(string customerId)
        {
            return await _context.EducationLoans.Where(e => e.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<PersonalLoan>> GetPersonalLoans(string customerId)
        {
            return await _context.PersonalLoans.Where(e => e.CustomerId == customerId).ToListAsync();
        }
    }
}
