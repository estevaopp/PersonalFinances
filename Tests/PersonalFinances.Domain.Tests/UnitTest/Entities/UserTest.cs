
namespace PersonalFinances.Domain.Tests.UnitTest.Entities
{
    public class UserTest
    {
        [Theory]
        [InlineData("jorge", "jorge@gamil.com", "Senha123?", 1)]
        [InlineData("maria", "maria@gamil.com", "Senha123?", 1)]
        public void CreateUser_ReturnSucess_CommandValid(string username, string email, string password, int userRoleId)
        {
            // Arrange
            // Act
            User user =  new User(username, email, password, userRoleId);

            // Assert
            Assert.True(true);
        }
    }
}