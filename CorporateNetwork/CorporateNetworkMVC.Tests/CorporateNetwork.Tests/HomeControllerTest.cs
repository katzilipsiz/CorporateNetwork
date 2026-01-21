using CorporateNetworkMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateNetwork.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = (ViewResult)controller.Index();

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = (ViewResult)controller.Index();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = (ViewResult)controller.Index();

            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}