using AuthorizationMS.DTO;
using AuthorizationMS.Interface;
using AuthorizationMS.Models;
using AuthorizationMS.Service;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AuthorizationTest
{
    public class ServiceTest
    {
        private Mock<IConfiguration> _config;
        private Mock<IAccountRepository> _repo;
        private AccountService _service;
        private Account account;

        public ServiceTest()
        {
            _config = new Mock<IConfiguration>();
            _repo = new Mock<IAccountRepository>();
            _service = new AccountService(_config.Object, _repo.Object);

            account = new Account()
            {
                CustomerId = "R-111",
                AccountNumber = 1111444477778888,
                Name = "Varun M",
                Username = "varun12",
                Password = "123456",
                GuardianType = "father",
                GuardianName = "Manoj",
                Address = "77/79",
                Citizenship = "indian",
                State = "karnataka",
                Country = "India",
                Email = "var@gmail.com",
                Gender = "male",
                MaritalStatus = "unmarried",
                ContactNumber = 8523698745,
                DateOfBirth = new DateTime(1998, 11, 06),
                RegistrationDate = new DateTime(2021, 06, 30),
                AccountType = "savings",
                BranchName = "Mysore",
                CitizenStatus = "adult",
                InitialDepositAmount = 6000,
                IdentificationType = "Aadhar",
                IdentificationDocumentNumber = "745896587458",
                ReferenceAccountHolderName = "Manoj",
                ReferenceAccountHolderAccountNumber = 1234567896541236,
                ReferenceAccountHolderAddress = "77/79"
            };
        }

        [Fact]
        public void LoginCheck_WhenGiven_CorrectCredentials_ReturnsTrue()
        {
            _repo.Setup(r => r.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(account));
            var result=_service.LoginCheck(new UserDTO() { Username = "varun12", Password = "123456" });

            Assert.True(result.Result);
        }
        [Fact]
        public void LoginCheck_WhenGiven_WrongCredentials_ReturnsFalse()
        {
            _repo.Setup(r => r.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(account));
            var result = _service.LoginCheck(new UserDTO() { Username = "varun12", Password = "12345" });

            Assert.False(result.Result);
        }

        [Fact]
        public void Update_WhenGiven_ValidUpdateDTO_ReturnsUpdatedSuccessfullyResponse()
        {
            _repo.Setup(r => r.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdateUser(It.IsAny<UpdateDTO>(), It.IsAny<string>())).Returns(Task.FromResult(true));
            var result = _service.UpdateUser(new UpdateDTO());

            Assert.Equal("details Updated successfully", result.Result);
        }
        [Fact]
        public void Update_WhenGiven_InvalidUpdateDTO_ReturnsUserNotFoundResponse()
        {
            _repo.Setup(r => r.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account =null));
            var result = _service.UpdateUser(new UpdateDTO());

            Assert.Equal("user does'nt exists", result.Result);
        }
        [Fact]
        public void Update_WhenGiven_ValidUpdateDTO_ReturnsErrorOccuredResponse()
        {
            _repo.Setup(r => r.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdateUser(It.IsAny<UpdateDTO>(), It.IsAny<string>())).Returns(Task.FromResult(false));
            var result = _service.UpdateUser(new UpdateDTO());

            Assert.Equal("could'nt update details some error occured", result.Result);
        }

        [Fact]
        public void ForgotPassword_WhenGivenForgotPasswordDTO_WithCorrectDateOfBirth_ReturnsTrue()
        {
            _repo.Setup(r => r.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdatePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));
            var result = _service.ForgotPassword(new ForgotPasswordDTO() { Username="varun12",DateOfBirth=new DateTime(1998,11,06),Password="123456"});

            Assert.True(result.Result);
        }
        [Fact]
        public void ForgotPassword_WhenGivenForgotPasswordDTO_WithInCorrectDateOfBirth_ReturnsFalse()
        {
            _repo.Setup(r => r.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdatePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));
            var result = _service.ForgotPassword(new ForgotPasswordDTO() { Username = "varun12", DateOfBirth = new DateTime(1968, 08, 16), Password = "123456" });
            
            
            Assert.False(result.Result);
        }
        [Fact]
        public void ChangePassword_WhenGivenChangePasswordDTO_WithCorrectOldPassword_ReturnsTrue()
        {
            _repo.Setup(r => r.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdatePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));
            var result = _service.ChangePassword(new ChangePasswordDTO() { CustomerId="R-111",OldPassword="123456",Password="qwerty"});
            

            Assert.True(result.Result);
        }
        [Fact]
        public void ChangePassword_WhenGivenChangePasswordDTO_WithInCorrectOldPassword_ReturnsFalse()
        {
            _repo.Setup(r => r.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account));
            _repo.Setup(r => r.UpdatePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));
            var result = _service.ChangePassword(new ChangePasswordDTO() { CustomerId = "R-111", OldPassword = "123456", Password = "qwerty" });
            

            Assert.False(result.Result);
        }
        [Fact]
        public void GenerateJWTToken_WhenGivenValidCredentials_ReturnsUSerTokenDTO()
        {
            _repo.Setup(r => r.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(account));
            _config.Setup(c => c["Token:SecretKey"]).Returns("mysecretkeyforthebankmanagementsystem");
            _config.Setup(c => c["Token:Issuer"]).Returns("mySystem");
            _config.Setup(c => c["Token:Audience"]).Returns("myUsers");
            var result = _service.CreateJwt(new UserDTO() { Username = "varun12", Password = "123456" });

            Assert.IsType<UserTokenDTO>(result.Result);
            Assert.Equal("R-111", result.Result.CustomerId);
        }
    }
}
