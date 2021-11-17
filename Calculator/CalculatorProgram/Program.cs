using System;

namespace CalculatorProgram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}