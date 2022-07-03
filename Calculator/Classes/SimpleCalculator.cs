using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Calculator
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly Logger _logger;
        private List<int> primeNumbers;

        public SimpleCalculator(Logger logger)
        {
            _logger = logger;
        }

        public int Add(int start, int amount)
        {
            _logger.Log($"Add: {start} + {amount} = {start + amount}");
            return start + amount;
        }
        public int Subtract(int start, int amount)
        {
            _logger.Log($"Subtract: {start} - {amount} = {start - amount}");
            return start - amount;
        }
        public int Multiply(int start, int by)
        {
            _logger.Log($"Multiply: {start} * {by} = {start * by}");
            return start * by;
        }

        public float Divide(int start, int by)
        {
            // Throw error if divide by 0
            if (by == 0)
            {
                _logger.Log("Cannot divide by zero.");
                throw new ArgumentException("Cannot divide by zero.");
            }

            var result = (float)start / (float)by;

            _logger.Log($"{start} / {by} = {result}");
            return result;
        }

        public int GetPrimeNumber(int selection)
        {
            var primeNumbers = new List<int>
            { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

            if (selection > primeNumbers.Count())
            {
                _logger.Log("Selection out of range");
                throw new ArgumentException("Selection beyond scope of prime numbers available.");
            }

            _logger.Log($"{selection} in prime numbers list = {primeNumbers.ElementAt(selection -1)}");
            return primeNumbers[selection];
        }
    }
}
