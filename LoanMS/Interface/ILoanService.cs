using LoanMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanMS.Interface
{
    public interface ILoanService
    {
        public Task AddEducationLoan(EducationLoan educationLoan);
        public Task AddPersonalLoan(PersonalLoan personalLoan);
        public Task<List<EducationLoan>> GetEducationLoans(string customerId);
        public Task<List<PersonalLoan>> GetPersonalLoans(string customerId);

    }
}
