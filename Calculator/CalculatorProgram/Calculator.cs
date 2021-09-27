using System;
using System.Linq;

namespace CalculatorProgram
{
    public class Calculator
    {
        public decimal Sum(params decimal[] numbers)
        {
            var result = 0.0M;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }
    }
}