using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class RevenueCategoryTest
    {
        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void CreateRevenueCategory_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var revenueCategory = new RevenueCategory(name, description, 1);

            // Act
            

            // Assert
            Assert.True(revenueCategory.Name == name && revenueCategory.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void CreateRevenueCategory_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange

            // Act
            

            // Assert
            Assert.Throws<BusinessException>(() => new RevenueCategory(name, description, 1));
        }


        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void UpdateRevenueCategory_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var revenueCategory = new RevenueCategory("Jorge", "luxo do luxo", 1);

            // Act
            revenueCategory.Update(name, description);
            

            // Assert
            Assert.True(revenueCategory.Name == name && revenueCategory.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void UpdateRevenueCategory_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange
            var revenueCategory = new RevenueCategory("Jorge", "luxo do luxo", 1);

            // Act
            
            // Assert
            Assert.Throws<BusinessException>(() => revenueCategory.Update(name, description));
        }
    }
}