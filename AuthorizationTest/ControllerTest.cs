using AuthorizationMS.Controllers;
using AuthorizationMS.DTO;
using AuthorizationMS.Interface;
using AuthorizationMS.Models;
using AuthorizationMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AuthorizationTest
{
    public class ControllerTest
    {
        private Mock<IAccountService> _mockservice;
        private AuthorizationController _controller;
        private Exception _exception;
        private List<string> usernames;
        private Account account;
        

        public ControllerTest()
        {
            _mockservice = new Mock<IAccountService>();
            _controller = new AuthorizationController(_mockservice.Object);
            _exception = new Exception();
            usernames = new List<string>();
            account = new Account();
        }

        [Fact]
        public void Login_WhenCalledWith_CorrectCredentials_ReturnOKResult()
        {
            _mockservice.Setup(s => s.LoginCheck(It.IsAny<UserDTO>())).Returns(Task.FromResult(true));
            _mockservice.Setup(s => s.CreateJwt(It.IsAny<UserDTO>())).Returns(Task.FromResult(new UserTokenDTO()));
            var response = _controller.Login(new UserDTO());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void Login_WhenCalledWith_WrongCredentials_ReturnBadRequestResult()
        {
            _mockservice.Setup(s => s.LoginCheck(It.IsAny<UserDTO>())).Returns(Task.FromResult(false));
            var response = _controller.Login(new UserDTO());
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
        [Fact]
        public void Login_WhenRaisesException_ReturnInternalServerError()
        {
            _mockservice.Setup(s => s.LoginCheck(It.IsAny<UserDTO>())).Throws(new Exception("error"));
            var response = _controller.Login(new UserDTO()).Result as ObjectResult;
            Assert.Equal(500,response.StatusCode);
        }

        [Fact]
        public void Register_WhenCalledWith_AccountObject_ReturnOKResult()
        {
            var response = _controller.Register(new Account());
            Assert.IsType<OkObjectResult>(response.Result);
        }
        [Fact]
        public void Register_WhenRaisesException_ReturnInternalServerError()
        {
            _mockservice.Setup(s => s.RegisterUser(It.IsAny<Account>())).Throws(new Exception("error"));
            var response = _controller.Register(new Account()).Result as ObjectResult;
            Assert.Equal(500, response.StatusCode);
        }

        [Fact]
        public void Update_WhenCalledWith_ValidCustomerId_UpdateDTO_ReturnsOkResult()
        {
            _mockservice.Setup(s => s.UpdateUser(It.IsAny<UpdateDTO>())).Returns(Task.FromResult("details Updated successfully"));
            var response = _controller.Update(new UpdateDTO());
            Assert.IsType<OkObjectResult>(response.Result);

        }

        [Fact]
        public void Update_WhenCalledWith_InvalidCustomerId_UpdateDTO_ReturnsBadRequestResult()
        {
            _mockservice.Setup(s => s.UpdateUser(It.IsAny<UpdateDTO>())).Returns(Task.FromResult("user does'nt exists"));
            var response = _controller.Update(new UpdateDTO());
            Assert.IsType<BadRequestObjectResult>(response.Result);

        }
        [Fact]
        public void Update_WhenRaisesExcption_ReturnsInternalServerError()
        {
            _mockservice.Setup(s => s.UpdateUser(It.IsAny<UpdateDTO>())).Throws(new Exception("error"));
            var response = _controller.Update(new UpdateDTO()).Result as ObjectResult;
            Assert.Equal(500, response.StatusCode);
        }

        [Fact]
        public void ForgotPassword_WhenCalledWith_CorrectDateOfBirth_ReturnOKResult()
        {
            _mockservice.Setup(s => s.ForgotPassword(It.IsAny<ForgotPasswordDTO>())).Returns(Task.FromResult(true));
            var response = _controller.ForgotPassword(new ForgotPasswordDTO());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void ForgotPassword_WhenCalledWith_WrongDateOfBirth_ReturnBadRequestResult()
        {
            _mockservice.Setup(s => s.ForgotPassword(It.IsAny<ForgotPasswordDTO>())).Returns(Task.FromResult(false));
            var response = _controller.ForgotPassword(new ForgotPasswordDTO());
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
        [Fact]
        public void ForgotPassword_WhenRaisesException_ReturnInternalServerError()
        {
            _mockservice.Setup(s => s.ForgotPassword(It.IsAny<ForgotPasswordDTO>())).Throws(new Exception("error"));
            var response = _controller.ForgotPassword(new ForgotPasswordDTO()).Result as ObjectResult;
            Assert.Equal(500,response.StatusCode);
        }
        [Fact]
        public void ChangePassword_WhenCalledWith_CorrectOldPassword_ReturnOKResult()
        {
            _mockservice.Setup(s => s.ChangePassword(It.IsAny<ChangePasswordDTO>())).Returns(Task.FromResult(true));
            var response = _controller.ChangePassword(new ChangePasswordDTO());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void ChangePassword_WhenCalledWith_WrongOldPassword_ReturnBadRequestResult()
        {
            _mockservice.Setup(s => s.ChangePassword(It.IsAny<ChangePasswordDTO>())).Returns(Task.FromResult(false));
            var response = _controller.ChangePassword(new ChangePasswordDTO());
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
        [Fact]
        public void ChangePassword_WhenRaisesException_ReturnInternalServerError()
        {
            _mockservice.Setup(s => s.ChangePassword(It.IsAny<ChangePasswordDTO>())).Throws(new Exception("error"));
            var response = _controller.ChangePassword(new ChangePasswordDTO()).Result as ObjectResult;
            Assert.Equal(500,response.StatusCode);
        }

        [Fact]
        public void GetUsernames_ReturnsOkObject()
        {
            _mockservice.Setup(s => s.GetUsernames()).Returns(Task.FromResult(usernames));
            var response = _controller.GetUsernames();
            Assert.IsType<OkObjectResult>(response.Result);
        }
        [Fact]
        public void GetUsernames_WhenRaisesException_ReturnsInternalServerError()
        {
            _mockservice.Setup(s => s.GetUsernames()).Throws(new Exception("error"));
            var response = _controller.GetUsernames().Result as ObjectResult;
            Assert.Equal(500,response.StatusCode);
        }

        [Fact]
        public void GetCustomer_WhenCalledWith_Valid_CustomerId_ReturnsOkObject()
        {
            _mockservice.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account));
            var response = _controller.GetCustomer("R-111");
            Assert.IsType<OkObjectResult>(response.Result);
        }
        [Fact]
        public void GetCustomer_WhenCalledWith_InValid_CustomerId_ReturnsBadRequestObject()
        {
            _mockservice.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(account=null));
            var response = _controller.GetCustomer("R-145");
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
        [Fact]
        public void GetCustomer_WhenRaisesException_ReturnsInternalServerError()
        {
            _mockservice.Setup(s => s.GetUserById(It.IsAny<string>())).Throws(new Exception("error"));
            var response = _controller.GetCustomer("R-145").Result as ObjectResult;
            Assert.Equal(500,response.StatusCode);
        }
    }
}
