using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using Xunit;

namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class ExpenditureTest
    {
        [Theory]
        [InlineData("Gasolina", 1, "2022-03-03", 200, "Abastecimento de gasolina", 1)]
        [InlineData("Gasolina", 1, null, 100, "Abastecimento de gasolina", 1)]
        public void CreateExpenditure_ReturnSucess_CommandValid(string name, int expenditureCategoryId, string date, decimal value, string description, int userId)
        {
            if(date == null)
            {
                var expenditure = new Expenditure(name, expenditureCategoryId, null, value, description, userId);

                Assert.True(expenditure.Name == name && expenditure.ExpenditureCategoryId == expenditureCategoryId && expenditure.Date == DateTime.Now.Date 
                        && expenditure.Value == value && expenditure.Description == description);
            }
            else
            {
                var expenditure = new Expenditure(name, expenditureCategoryId, DateTime.Parse(date), value, description, userId);


                Assert.True(expenditure.Name == name && expenditure.ExpenditureCategoryId == expenditureCategoryId && expenditure.Date == DateTime.Parse(date) 
                        && expenditure.Value == value && expenditure.Description == description && expenditure.UserId == userId);
            }
        }

        [Theory]
        [InlineData("    ", 1, "2022-03-03", 200, "Abastecimento de gasolina", 1)]
        [InlineData("", 1, "2022-03-03", 200, "Abastecimento de gasolina", 1)]
        [InlineData("as", 1, "2022-03-03", 100, "Abastecimento de gasolina", 1)]
        [InlineData(null, 1, "2022-03-03", 100, "Abastecimento de gasolina", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", 0, "Abastecimento de gasolina", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", -100, "Abastecimento de gasolina", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "        ", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "as", 1)]
        [InlineData("Gasolina", 1, "2022-03-03", 100, null, 1)]
        public void CreateExpenditure_ReturnBusinessException_CommandInvalid(string name, int expenditureCategoryId, string date, decimal value, string description, int userId)
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<BusinessException>(() => new Expenditure(name, expenditureCategoryId, DateTime.Parse(date), value, description, userId));
        }


        [Theory]
        [InlineData("Gasolina", 1, "2022-03-03", 200, "Abastecimento de gasolina")]
        [InlineData("Gasolinaa", 1, "2022-03-05", 100, "Abastecimento de gasolinaaa")]
        public void UpdateExpenditure_ReturnSucess_CommandValid(string name, int expenditureCategoryId, string date, decimal value, string description)
        {
            var expenditure = new Expenditure("Comida", 5, new DateTime(2020,3,3), 1000, "Compra mensal", 1);

            expenditure.Update(name, expenditureCategoryId, DateTime.Parse(date), value, description);


            Assert.True(expenditure.Name == name && expenditure.ExpenditureCategoryId == expenditureCategoryId && expenditure.Date == DateTime.Parse(date) 
                    && expenditure.Value == value && expenditure.Description == description && expenditure.UserId == 1);
        }

        [Theory]
        [InlineData("    ", 1, "2022-03-03", 200, "Abastecimento de gasolina")]
        [InlineData("", 1, "2022-03-03", 200, "Abastecimento de gasolina")]
        [InlineData("as", 1, "2022-03-03", 100, "Abastecimento de gasolina")]
        [InlineData(null, 1, "2022-03-03", 100, "Abastecimento de gasolina")]
        [InlineData("Gasolina", 1, "2022-03-03", 0, "Abastecimento de gasolina")]
        [InlineData("Gasolina", 1, "2022-03-03", -100, "Abastecimento de gasolina")]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "        ")]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "")]
        [InlineData("Gasolina", 1, "2022-03-03", 100, "as")]
        [InlineData("Gasolina", 1, "2022-03-03", 100, null)]
        public void UpdateExpenditure_ReturnBusinessException_CommandInvalid(string name, int expenditureCategoryId, string date, decimal value, string description)
        {
            // Arrange
            var expenditure = new Expenditure("Comida", 5, new DateTime(2020,3,3), 1000, "Compra mensal", 1);
            // Act

            // Assert
            Assert.Throws<BusinessException>(() => expenditure.Update(name, expenditureCategoryId, DateTime.Parse(date), value, description));
        }
    }
}