using Xunit;
using Microsoft.AspNetCore.Mvc;
using MyProject.Controllers;
using Microsoft.Extensions.Logging.Abstractions;

namespace MyProject.UnitTests
{
    [Trait("Category", "Unit")]
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var logger = new NullLogger<HomeController>();
            var controller = new HomeController(logger);
            
            // Act
            var result = controller.Index();
            
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view is expected
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var logger = new NullLogger<HomeController>();
            var controller = new HomeController(logger);
            
            // Act
            var result = controller.Privacy();
            
            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}