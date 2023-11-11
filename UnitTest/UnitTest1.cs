using Moq;
using senior_food_order_system_auth.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using senior_food_order_system_auth;
using Microsoft.EntityFrameworkCore;

namespace test;

[TestClass]
public class UnitTest1
{
    private AuthController _authController;
    private Mock<IConfiguration> _mockConfiguration;
    private Mock<SeniorFoodOrderSystemDatabaseContext> _mockDbContext;

    [TestInitialize]
    public void Initialize()
    {
        _mockConfiguration = new Mock<IConfiguration>();
        _mockConfiguration.Setup(x => x.GetSection("AppSettings:Token").Value).Returns("your_expected_token_value");

        _mockDbContext = new Mock<SeniorFoodOrderSystemDatabaseContext>();

        // Mock the Users property to return a DbSet<User>
        var users = new List<User>(); // Add your desired users to this list
        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.AsQueryable().Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.AsQueryable().Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.AsQueryable().ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.AsQueryable().GetEnumerator());

        _mockDbContext.Setup(x => x.Users).Returns(mockSet.Object);


        _authController = new AuthController(_mockConfiguration.Object, _mockDbContext.Object);
    }

    [TestMethod]
    public async Task LoginWithPhoneNo_ReturnsOk()
    {
        // Arrange
        string phoneNo = "1234567890";

        // Act
        var result = await _authController.LoginWithPhoneNo(phoneNo) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
        Assert.IsNotNull(result.Value); // Assuming the token is returned in the response

        // Additional assertions or verifications based on your actual implementation
    }
}
