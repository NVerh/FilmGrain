using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Logic;
using Xunit;
using Moq;
using FilmGrain.Interfaces.Mock;

namespace FilmGrain.Tests
{
    public class AccountTests
    {
        private readonly IUserMock _mock;

        public AccountTests(IUserMock mock)
        {
            _mock = mock;
        }
        [Theory]
        [InlineData("Test12345","NTest","Test@Test.nl")]
        public void CreateAccount_Successful(string username, string password, string email)
        {
            UserDTO Expected = new UserDTO
            {
                Email = email,
                UserName = username,
                Password = password
            };
            _mock.Create(Expected);
            var actual = _mock.GetAccountFromDB("Test12345", "NTest");

            Assert.Equal(Expected.Email, actual.Email);
            Assert.Equal(Expected.Password, actual.Password);
            Assert.Equal(Expected.UserName, actual.UserName);
        }
        [Theory]
        [InlineData(0,"ninoverheijen@hotmail.com", "Test123")]
        public void ValidateUser_Succesful(int id, string email, string password)
        {
            UserDTO expected = new UserDTO
            {
                Id = id,
                Email = email,
                Password = password
            };
            var actual = _mock.Read(id);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.UserName, actual.UserName);
        }
        [Fact]
        public void DeleteUser_Succesful()
        {
            UserDTO user = new UserDTO { Id = 3 };

           bool result = _mock.Delete(user);

            Assert.True(result);
        }
        [Fact]
        public void DeleteUser_Unsuccesful()
        {
            UserDTO user = new UserDTO { Id = 7 };
            bool result = _mock.Delete(user);

            Assert.False(result);
        }
        [Theory]
        [InlineData("HenkSluipers@gmail.com")]
        public void GetAccountByEmail_Check_If_Email_Is_Valid(string email)
        {

        }
    }
}
