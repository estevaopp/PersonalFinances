using System;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Entities;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class UserTest
    {
        [Theory]
        [InlineData("jorge", "jorge@gamil.com", "Senha123?", 1)]
        [InlineData("maria", "maria@gamil.com", "Senha123", 1)]
        public void CreateUser_ReturnSucess_CommandValid(string username, string email, string password, int userRoleId)
        {
            // Arrange
            var user = new User(username, email, password, userRoleId);

            // Act
            

            // Assert
            Assert.True(user.Username == username && user.Email == email && user.Password == password 
                        && user.UserRoleId == userRoleId && user.IsEmailValid == false);
        }

        [Theory]
        [InlineData(null, "jorge@gamil.com", "Senha123?", 1)]
        [InlineData("  ", "jorge@gamil.com", "Senha123?", 1)]
        [InlineData("maria", null, "Senha123?", 1)]
        [InlineData("maria", "", "Senha123?", 1)]
        [InlineData("maria", "", "Senha123?", 1)]
        [InlineData(null, "", "Senha123?", 1)]
        public void CreateUser_ReturnBusinessException_NullValues(string username, string email, string password, int userRoleId)
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<BusinessException>(() => new User(username, email, password, userRoleId));
        }

        [Theory]
        [InlineData("jorge", "jorge@gamil.com", "SENHA123?", 1)]
        [InlineData("maria", "maria@gamil.com", "senha123?", 1)]
        [InlineData("maria", "maria@gamil.com", "Senhaas?", 1)]
        [InlineData("maria", "maria@gamil.com", "sssss123?", 1)]
        [InlineData("maria", "maria@gamil.com", "s", 1)]
        [InlineData("maria", "maria@gamil.com", null, 1)]
        [InlineData("maria", "maria@gamil.com", "", 1)]
        [InlineData("maria", "maria@gamil.com", " ", 1)]
        public void CreateUser_ReturnBusinessException_InvalidPassword(string username, string email, string password, int userRoleId)
        {
            // Arrange
            // Act
            

            // Assert
            Assert.Throws<BusinessException>(() => new User(username, email, password, userRoleId));
        }
    }
}