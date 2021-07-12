using LoanMS.Interface;
using LoanMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanMS.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository repo)
        {
            _loanRepository = repo;
        }
        public async Task AddEducationLoan(EducationLoan educationLoan)
        {
            await _loanRepository.AddEducationLoan(educationLoan);
        }

        public async Task AddPersonalLoan(PersonalLoan personalLoan)
        {
            await _loanRepository.AddPersonalLoan(personalLoan);
        }

        public async Task<List<EducationLoan>> GetEducationLoans(string customerId)
        {
            return await _loanRepository.GetEducationLoans(customerId);
        }

        public async Task<List<PersonalLoan>> GetPersonalLoans(string customerId)
        {
            return await _loanRepository.GetPersonalLoans(customerId);
        }
    }
}
