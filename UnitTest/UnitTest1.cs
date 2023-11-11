using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using senior_food_order_system_auth.Controllers;
using senior_food_order_system_auth;
using Moq;

namespace test;

[TestClass]
public class UnitTest1
{
    private AuthController _authController;
    private Mock<IConfiguration> _mockConfiguration;
    private Mock<SeniorFoodOrderSystemDatabaseContext> _dbConfiguration;

    [TestInitialize]
    public void Initialize()
    {
        _mockConfiguration = new Mock<IConfiguration>();
        _dbConfiguration = new Mock<SeniorFoodOrderSystemDatabaseContext>();
        _authController = new AuthController(_mockConfiguration.Object, _dbConfiguration.Object);
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
    }
}
