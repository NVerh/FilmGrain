using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Services;
using System.Security.Policy;

namespace FilmGrain.Tests.Services
{
    public class PasswordHashTests
    {
        [Fact]
        public void Hash_Validate_Match_Text()
        {
            // Arrange
            var message = "sUpErSekrItPass!123";
            var salt = PasswordSalt.Create();
            var hash = PasswordHash.Create(message, salt);

            // Act
            var match = PasswordHash.Validate(message, salt, hash);

            // Assert
            Assert.True(match);
        }
        [Fact]
        public void Fake_Hash_Valides_Does_Not_Match_Text()
        {
            // Arrange
            var message = "sUpErSekrItPass!123";
            var salt = PasswordSalt.Create();
            var hash = "1010101010FAKEHASHHIHI011010101";

            // Act
            var match = PasswordHash.Validate(message, salt, hash);

            Assert.False(match);
        }
        [Fact]
        public void Two_Same_Message_Have_Different_Salt()
        {
            var message1 = "password12";
            var message2 = "password12";
            var salt = PasswordSalt.Create();
            var salt2 = PasswordSalt.Create();

            // Act
            var hash1 = PasswordHash.Create(message1, salt);
            var hash2 = PasswordHash.Create(message2, salt2);

            //Assert
            Assert.True(hash1 != hash2);
        }
        [Fact]
        public void Two_Different_Messages_Dont_Match()
        {
            // Arrange
            var message1 = "password123";
            var message2 = "password1234";
            var salt = PasswordSalt.Create();

            // Act
            var hash1 = PasswordHash.Create(message1, salt);
            var hash2 = PasswordHash.Create(message2, salt);

            //Assert
            Assert.True(hash1 != hash2);
           
        }
    }
}
