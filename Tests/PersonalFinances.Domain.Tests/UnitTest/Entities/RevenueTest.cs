using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class RevenueTest
    {
        [Theory]
        [InlineData("Freelance", 1, "2022-03-03", 200, "Salario no freelance", 1)]
        [InlineData("Freelance", 1, null, 100, "Salario no freelance", 1)]
        public void CreateRevenue_ReturnSucess_CommandValid(string name, int revenueCategoryId, string date, decimal value, string description, int userId)
        {
            if(date == null)
            {
                var revenue = new Revenue(name, revenueCategoryId, null, value, description, userId);

                Assert.True(revenue.Name == name && revenue.RevenueCategoryId == revenueCategoryId && revenue.Date == DateTime.Now.Date 
                        && revenue.Value == value && revenue.Description == description);
            }
            else
            {
                var revenue = new Revenue(name, revenueCategoryId, DateTime.Parse(date), value, description, userId);


                Assert.True(revenue.Name == name && revenue.RevenueCategoryId == revenueCategoryId && revenue.Date == DateTime.Parse(date) 
                        && revenue.Value == value && revenue.Description == description && revenue.UserId == userId);
            }
        }

        [Theory]
        [InlineData("    ", 1, "2022-03-03", 200, "Salario no freelance", 1)]
        [InlineData("", 1, "2022-03-03", 200, "Salario no freelance", 1)]
        [InlineData("as", 1, "2022-03-03", 100, "Salario no freelance", 1)]
        [InlineData(null, 1, "2022-03-03", 100, "Salario no freelance", 1)]
        [InlineData("Freelance", 1, "2022-03-03", 0, "Salario no freelance", 1)]
        [InlineData("Freelance", 1, "2022-03-03", -100, "Salario no freelance", 1)]
        [InlineData("Freelance", 1, "2022-03-03", 100, "        ", 1)]
        [InlineData("Freelance", 1, "2022-03-03", 100, "", 1)]
        [InlineData("Freelance", 1, "2022-03-03", 100, "as", 1)]
        [InlineData("Freelance", 1, "2022-03-03", 100, null, 1)]
        public void CreateRevenue_ReturnBusinessException_CommandInvalid(string name, int revenueCategoryId, string date, decimal value, string description, int userId)
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<BusinessException>(() => new Revenue(name, revenueCategoryId, DateTime.Parse(date), value, description, userId));
        }


        [Theory]
        [InlineData("Freelance", 1, "2022-03-03", 200, "Salario no freelance")]
        [InlineData("Freelancer", 1, "2022-03-06", 400, "Salario no freelancer")]
        public void UpdateRevenue_ReturnSucess_CommandValid(string name, int revenueCategoryId, string date, decimal value, string description)
        {
            var revenue = new Revenue("Salario", 5, new DateTime(2020,3,3), 1000, "Salario do emprego", 1);

            revenue.Update(name, revenueCategoryId, DateTime.Parse(date), value, description);


            Assert.True(revenue.Name == name && revenue.RevenueCategoryId == revenueCategoryId && revenue.Date == DateTime.Parse(date) 
                    && revenue.Value == value && revenue.Description == description && revenue.UserId == 1);
            
        }

        [Theory]
        [InlineData("    ", 1, "2022-03-03", 200, "Salario no freelance")]
        [InlineData("", 1, "2022-03-03", 200, "Salario no freelance")]
        [InlineData("as", 1, "2022-03-03", 100, "Salario no freelance")]
        [InlineData(null, 1, "2022-03-03", 100, "Salario no freelance")]
        [InlineData("Freelance", 1, "2022-03-03", 0, "Salario no freelance")]
        [InlineData("Freelance", 1, "2022-03-03", -100, "Salario no freelance")]
        [InlineData("Freelance", 1, "2022-03-03", 100, "        ")]
        [InlineData("Freelance", 1, "2022-03-03", 100, "")]
        [InlineData("Freelance", 1, "2022-03-03", 100, "as")]
        [InlineData("Freelance", 1, "2022-03-03", 100, null)]
        public void UpdateRevenue_ReturnBusinessException_CommandInvalid(string name, int revenueCategoryId, string date, decimal value, string description)
        {
            // Arrange
            var revenue = new Revenue("Salario", 5, new DateTime(2020,3,3), 1000, "Salario do emprego", 1);
            // Act

            // Assert
            Assert.Throws<BusinessException>(() => revenue.Update(name, revenueCategoryId, DateTime.Parse(date), value, description));
        }
    }
}