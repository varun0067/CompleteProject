using LoanMS.Interface;
using LoanMS.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoanMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly ILog _log4net = LogManager.GetLogger(typeof(LoanController));

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }


        [HttpPost("addEducationLoan")]
        public async Task<IActionResult> AddEducationLoan([FromBody] EducationLoan educationLoan)
        {
            _log4net.Info("Adding Education loan details ");
            try
            {
                await _loanService.AddEducationLoan(educationLoan);
                _log4net.Info("Eduaction Loan details added.");
                return Ok();
            }
            catch(Exception ex)
            {
                _log4net.Error("Something went wrong. " + ex.Message);
                return StatusCode(500, "Internal Sever error." + ex.Message);
            }
               
        }

        [HttpPost("addPersonalLoan")]
        public async Task<IActionResult> AddPersonalLoan([FromBody] PersonalLoan personalLoan)
        {
            _log4net.Info("Adding Personal loan details ");
            try
            {
                await _loanService.AddPersonalLoan(personalLoan);
                _log4net.Info("Personal Loan details added.");
                return Ok();
            }
            catch (Exception ex)
            {
                _log4net.Error("Something went wrong. " + ex.Message);
                return StatusCode(500, "Internal Sever error." + ex.Message);
            }
        }

        [HttpGet("getEducationLoans/{customerId}")]
        public async Task<IActionResult> GetEducationLoans(string customerId)
        {
            _log4net.Info("Getting education loan details of " + customerId);
            try
            {
                _log4net.Info("Returning education loan details of " + customerId);
                return Ok(await _loanService.GetEducationLoans(customerId));
            }
            catch(Exception ex)
            {
                _log4net.Error("Something went wrong. " + ex.Message);
                return StatusCode(500, "Internal Sever error." + ex.Message);
            }
            
        }

        [HttpGet("getPersonalLoans/{customerId}")]
        public async Task<IActionResult> GetPersonalLoan(string customerId)
        {
            _log4net.Info("Getting personal loan details of " + customerId);
            try
            {
                _log4net.Info("Returning pernonal loan details of " + customerId);
                return Ok(await _loanService.GetPersonalLoans(customerId));
            }
            catch(Exception ex)
            {
                _log4net.Error("Something went wrong. " + ex.Message);
                return StatusCode(500, "Internal Sever error." + ex.Message);
            }
        }
    }
}
