using System;
using System.Linq;

namespace CalculatorProgram
{
    public class Calculator
    {
        public decimal Current { get; set; }

        public decimal Sum(params decimal[] numbers)
        {
            if (numbers.Length == 1)
            {
                Current += numbers[0];
                return Current;
            }
            var result = 0.0M;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }

        public decimal Multiply(params decimal[] numbers)
        {
            ValidateNumbers(numbers);
            if (numbers.Length == 1)
            {
                Current *= numbers[0];
                return Current;
            }

            var result = numbers[0];
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                result *= numbers[i];
            }
            return result;
        }

        private void ValidateNumbers(decimal[] numbers)
        {
            if (numbers.Any(number => number == decimal.MaxValue))
            {
                throw new InvalidOperationException("Not a valid number to use");
            }
        }

        public decimal Divide(params decimal[] numbers)
        {
            if (numbers.Length == 1)
            {
                Current /= numbers[0];
                return Current;
            }

            var result = numbers[0];
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                result /= numbers[i];
            }
            return result;
        }

        public void Reset()
        {
            Current = 0;
        }
    }
}