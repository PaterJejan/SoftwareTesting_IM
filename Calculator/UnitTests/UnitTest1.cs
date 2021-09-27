using CalculatorProgram;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_AddTwoElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // 2) Act (the actual operation)
            var result = calculator.Sum(1, 1);

            // 3) Then, Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_AddManyElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // 2) Act (the actual operation)
            var result = calculator.Sum(0.5M, 1, 2, 3, 4, -5.5M);

            // 3) Then, Assert
            Assert.Equal(5, result);
            Assert.IsType<decimal>(result);
        }
    }
}