using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class UserRoleTest
    {
        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void CreateUserRole_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var userRole = new UserRole(name, description);

            // Act
            

            // Assert
            Assert.True(userRole.Name == name && userRole.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void CreateUserRole_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange

            // Act
            

            // Assert
            Assert.Throws<BusinessException>(() => new UserRole(name, description));
        }


        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void UpdateUserRole_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var userRole = new UserRole("Jorge", "luxo do luxo");

            // Act
            userRole.Update(name, description);
            

            // Assert
            Assert.True(userRole.Name == name && userRole.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void UpdateUserRole_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange
            var userRole = new UserRole("Jorge", "luxo do luxo");

            // Act
            
            // Assert
            Assert.Throws<BusinessException>(() => userRole.Update(name, description));
        }
    }
}