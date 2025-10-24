using Xunit;
using MyProject.Models;

namespace MyProject.UnitTests
{
    [Trait("Category", "Unit")]
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnSum_WhenGivenTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = calculator.Add(1, 2);
            
            // Assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(100, 200, 300)]
        public void Add_ShouldReturnCorrectSum_ForVariousInputs(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = calculator.Add(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}