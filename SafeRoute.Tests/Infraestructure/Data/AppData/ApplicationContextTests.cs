using Microsoft.EntityFrameworkCore;
using SafeRoute.Domain.Entities;
using SafeRoute.Infraestructure.Data.AppData;

namespace SafeRoute.Tests.Infraestructure.Data.AppData;

public class ApplicationContextTests
{
    private DbContextOptions<ApplicationContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public void CanAddAndRetrieveUser()
    {
        // Arrange
        var options = GetInMemoryOptions();
        using (var context = new ApplicationContext(options))
        {
            var user = new User
            {
                Name = "John Doe",
                Cpf = "12345678900",
                Email = "john@example.com",
                Phone = "123456789"
            };

            // Act
            context.Users.Add(user);
            context.SaveChanges();
        }

        // Assert
        using (var context = new ApplicationContext(options))
        {
            var user = context.Users.FirstOrDefault(a => a.Email == "john@example.com");
            Assert.NotNull(user);
            Assert.Equal("John Doe", user.Name);
        }
    }
}
