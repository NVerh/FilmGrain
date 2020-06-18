using FilmGrain.DTO;
using FilmGrain.Interfaces.Mock;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Frameworks;
using System;
using System.Reflection.Metadata.Ecma335;
using Xunit;
using FilmGrain.DAL.Mock;

namespace FilmGrain.Test
{
    public class AccountTests
    {
        private readonly IUserMock _userMockRepository = new UserMockRepository();

        [Theory]
        [InlineData("Test12345", "NTest", "Test@Test.nl")]
        public void CreateAccount_Successful(string username, string password, string email)
        {
            UserDTO Expected = new UserDTO
            {
                Email = email,
                UserName = username,
                Password = password
            };
            bool addedAccount = _userMockRepository.Create(Expected);
            Assert.Equal(true, addedAccount);
        }
        [Theory]
        [InlineData(0, "TomTrapper@gmail.com", "Test123")]
        public void ValidateUser_ByEmailAnd_Password(int id, string email, string password)
        {
            UserDTO expected = new UserDTO
            {
                Id = id,
                Email = email,
                Password = password
            };
            UserDTO actual = _userMockRepository.GetAccountByEmail(email);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.Password, actual.Password);
        }
        [Theory]
        [InlineData("HS","HS2")]
        public void ValidateUser_ByUserNameAnd_Password( string username, string password)
        {
            UserDTO expected = new UserDTO
            {
                UserName = username,
                Password = password,
            };
            UserDTO actual = _userMockRepository.GetAccountFromDB(username, password);
            Assert.Equal(expected.UserName, actual.UserName);
            Assert.Equal(expected.Password, actual.Password);
        }
        [Theory]
        [InlineData(10, "KevinK", "KKRules","Kevin@gmail.com")]
        public void CreateUser_Full_Credentials_Succesfull(int id, string username, string password, string email)
        {
            UserDTO expected = new UserDTO
            {
                Id = id,
                UserName = username,
                Password = password,
                Email = email,
            };
            bool addAccount = _userMockRepository.Create(expected);
            Assert.Equal(true, addAccount);
        }
        [Fact]
        public void DeleteUser_Succesful()
        {
            UserDTO user = new UserDTO { Id = 1 };
            bool result = _userMockRepository.Delete(user);

            Assert.True(result);
        }
        [Fact]
        public void DeleteUser_Unsuccesful()
        {
            UserDTO user = new UserDTO { Id = 0 };
            bool result = _userMockRepository.Delete(user);

            Assert.False(result);
        }
        [Theory]
        [InlineData("HenkSluipers@gmail.com")]
        public void GetAccountByEmail_Check_If_Email_Is_Valid(string email)
        {
            UserDTO user = _userMockRepository.GetAccountByEmail(email);
            Assert.NotNull(user);
        }
    }
}
