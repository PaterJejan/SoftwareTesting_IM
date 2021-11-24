using CalculatorProgram;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class MultiplyDivideTests
    {
        [Fact]
        public void Test_Validations()
        {
            // 1) Arrange
            var calculator = new Calculator();

            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Multiply(decimal.MaxValue, decimal.MaxValue);

                // Then, Assert
                Assert.IsType<decimal>(result);

                int n1 = 25;
                int n2 = 10;

                double x = (double)n1 / n2;
                Assert.Equal(2.5, x);
                x = n1 / n2;
                Assert.Equal(2, x);
            });

            Assert.Equal("Not a valid number to use", exception.Message);

            exception = Assert.Throws<DivideByZeroException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Divide(decimal.MaxValue, 0);

                // Then, Assert
                Assert.IsType<decimal>(result);
            });

            Assert.IsType<DivideByZeroException>(exception);
        }

        [Fact]
        public void Test_DivideByZero()
        {
            // 1) Arrange
            var calculator = new Calculator();

            Assert.Throws<DivideByZeroException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Divide(1, 0);

                // Then, Assert
                Assert.IsType<decimal>(result);
            });
        }

        [Fact]
        public void Test_MultiplyTwoElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Multiply(10, 5);

            // Then, Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void Test_MultiplyManyElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Multiply(0.5M, 1, 2, 3, 4, -5.5M);

            // Then, Assert
            Assert.Equal(-66, result);
            Assert.IsType<decimal>(result);
        }

        [Fact]
        public void Test_DivideTwoElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Divide(10, 5);

            // Then, Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_DivideManyElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Divide(100, 2, 4);

            // Then, Assert
            Assert.Equal((decimal)12.5, result);
            Assert.IsType<decimal>(result);
        }
    }

    public class CalculatorMemoryTests : IDisposable
    {
        private Calculator Calculator { get; }

        public CalculatorMemoryTests()
        {
            Calculator = new Calculator();
        }

        [Fact]
        public void AddNumberTest()
        {
            Calculator.Reset();

            // Act
            Calculator.Sum(3);
            Calculator.Sum(7);

            Assert.Equal(10, Calculator.Current);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }

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

        [Fact]
        public void Test_MaintenanceDateHit()
        {
            // 1) Arrange
            var mockDateTime = new Moq.Mock<IDateTimeProvider>();
            mockDateTime.Setup(mock => mock.GetNow()).Returns(() => new DateTime(2100, 1, 1, 0, 0, 0));

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var calculator = new Calculator(mockDateTime.Object);
            });

            // Then, Assert
            Assert.True(exception.Message.Contains("time to make some maintenance!"));

            mockDateTime.Verify(mock => mock.GetNow(), Times.Once);
        }
    }
}