using LoanMS.Controllers;
using LoanMS.Interface;
using LoanMS.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LoanTest
{
    public class ControllerTest
    {
        private Mock<ILoanService> _service;
        private LoanController _controller;
        private List<EducationLoan> EducationLoans;
        private List<PersonalLoan> PersonalLoans;
        private List<EducationLoan> EmptyEducationLoans;
        private List<PersonalLoan> EmptyPersonalLoans;
        public ControllerTest()
        {
            _service = new Mock<ILoanService>();
            _controller = new LoanController(_service.Object);
            EducationLoans = new List<EducationLoan>()
            {
                    new EducationLoan()
                    {
                    LoanId = 1,
                    CustomerId = "R-111",
                    Amount = 1000000,
                    LoanApplyDate= new DateTime(2021, 7, 1),
                    LoanIssueDate = new DateTime(2021, 7, 23),
                    RateOfInterest = 10,
                    DurationOfLoan = "15",
                    FatherName = "Ramesh",
                    Course = "BE",
                    CourseFee = 100000,
                    FatherOccupation = "HR",
                    FatherTotalExperience = 5,
                    FatherExperienceInCurrentCompany = 2,
                    RationCardNumber = 123456,
                    AnnualIncome = 1000
                },
            };
            PersonalLoans = new List<PersonalLoan>()
            {
                new PersonalLoan()
                {
                    LoanId = 1,
                    CustomerId = "R-111",
                    Amount = 1000000,
                    LoanApplyDate= new DateTime(2021, 7, 1),
                    LoanIssueDate = new DateTime(2021, 12, 23),
                    RateOfInterest = 10,
                    DurationOfLoan = "15",
                    AnnualIncome = 500000,
                    CompanyName = "Cognizant",
                    Designation = "PAT",
                    TotalExperience = 4,
                    ExperienceInCurrentCompany = 2
                },
            };

            EmptyEducationLoans = new List<EducationLoan>();
            EmptyPersonalLoans = new List<PersonalLoan>();
        }
        [Fact]
        public void AddEducationLoan_WhenCalledWithEducationLoanObject_ReturnsOkResult()
        {
            _service.Setup(s => s.AddEducationLoan(It.IsAny<EducationLoan>()));
            var response=_controller.AddEducationLoan(new EducationLoan());

            Assert.IsType<OkResult>(response.Result);
        }
        [Fact]
        public void AddEducationLoan_WhenRaisesException_ReturnsInternalServerError()
        {
            _service.Setup(s => s.AddEducationLoan(It.IsAny<EducationLoan>())).Throws(new Exception("error"));
            var response = _controller.AddEducationLoan(new EducationLoan()).Result as ObjectResult;

            Assert.Equal(500,response.StatusCode);
        }
        [Fact]
        public void AddPersonalLoan_WhenCalledWithPersonalLoanObject_ReturnsOkResult()
        {
            _service.Setup(s => s.AddPersonalLoan(It.IsAny<PersonalLoan>()));
            var response = _controller.AddPersonalLoan(new PersonalLoan());

            Assert.IsType<OkResult>(response.Result);
        }
        [Fact]
        public void AddPersonalLoan_WhenRaisesException_ReturnsInternalServerError()
        {
            _service.Setup(s => s.AddPersonalLoan(It.IsAny<PersonalLoan>())).Throws(new Exception("error"));
            var response = _controller.AddPersonalLoan(new PersonalLoan()).Result as ObjectResult;

            Assert.Equal(500, response.StatusCode);
        }
        [Fact]
        public void GetEducationLoan_WhenGiveCoorrectCustomerId_ReturnsOkResultWithListOfEducationLoan()
        {
            _service.Setup(s => s.GetEducationLoans(It.IsAny<string>())).Returns(Task.FromResult(EducationLoans));
            var result=_controller.GetEducationLoans("R-111").Result as OkObjectResult;

            Assert.Equal(EducationLoans, result.Value);
        }
        [Fact]
        public void GetEducationLoan_WhenGiveWrongCustomerId_ReturnsOkResultWithEmptyListOfEducationLoan()
        {
            _service.Setup(s => s.GetEducationLoans(It.IsAny<string>())).Returns(Task.FromResult(EmptyEducationLoans));
            var result = _controller.GetEducationLoans("R-123").Result as OkObjectResult;

            Assert.Equal(EmptyEducationLoans, result.Value);
        }
        [Fact]
        public void GetEducationLoan_WhenRaisesException_ReturnsInternalServerError()
        {
            _service.Setup(s => s.GetEducationLoans(It.IsAny<string>())).Throws(new Exception("error"));
            var result = _controller.GetEducationLoans("R-123").Result as ObjectResult;

            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void GetPersonalLoan_WhenGiveCoorrectCustomerId_ReturnsOkResultWithListOfPersonalLoan()
        {
            _service.Setup(s => s.GetPersonalLoans(It.IsAny<string>())).Returns(Task.FromResult(PersonalLoans));
            var result = _controller.GetPersonalLoan("R-111").Result as OkObjectResult;

            Assert.Equal(PersonalLoans, result.Value);
        }
        [Fact]
        public void GetPersonalLoan_WhenGiveWrongCustomerId_ReturnsOkResultWithEmptyListOfPersonalLoan()
        {
            _service.Setup(s => s.GetPersonalLoans(It.IsAny<string>())).Returns(Task.FromResult(EmptyPersonalLoans));
            var result = _controller.GetPersonalLoan("R-123").Result as OkObjectResult;

            Assert.Equal(EmptyPersonalLoans, result.Value);
        }
        [Fact]
        public void GetPersonalLoan_WhenRaisesException_ReturnsInternalServerError()
        {
            _service.Setup(s => s.GetPersonalLoans(It.IsAny<string>())).Throws(new Exception("error"));
            var result = _controller.GetPersonalLoan("R-123").Result as ObjectResult;

            Assert.Equal(500, result.StatusCode);
        }
    }
}
