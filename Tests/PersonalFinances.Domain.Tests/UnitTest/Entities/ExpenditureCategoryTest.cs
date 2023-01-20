using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class ExpenditureCategoryTest
    {
        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void CreateExpenditureCategory_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var expenditureCategory = new ExpenditureCategory(name, description);

            // Act
            

            // Assert
            Assert.True(expenditureCategory.Name == name && expenditureCategory.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void CreateExpenditureCategory_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange

            // Act
            

            // Assert
            Assert.Throws<BusinessException>(() => new ExpenditureCategory(name, description));
        }


        [Theory]
        [InlineData("Name", "Description")]
        [InlineData("Nam", "Descr")]
        public void UpdateExpenditureCategory_ReturnSucess_CommandValid(string name, string description)
        {
            // Arrange
            var expenditureCategory = new ExpenditureCategory("Jorge", "luxo do luxo");

            // Act
            expenditureCategory.Update(name, description);
            

            // Assert
            Assert.True(expenditureCategory.Name == name && expenditureCategory.Description == description);
        }

        [Theory]
        [InlineData("    ", "Description")]
        [InlineData("", "Description")]
        [InlineData("Na", "Description")]
        [InlineData("Name", "      ")]
        [InlineData("Name", "")]
        [InlineData("Name", "desc")]
        public void UpdateExpenditureCategory_ReturnBusinessException_CommandInvalid(string name, string description)
        {
            // Arrange
            var expenditureCategory = new ExpenditureCategory("Jorge", "luxo do luxo");

            // Act
            
            // Assert
            Assert.Throws<BusinessException>(() => expenditureCategory.Update(name, description));
        }
    }
}