using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var calc = new SimpleCalculator(logger);

            var operation = GetOperator();
            if (operation != 'p')
            {
                var number1 = GetNumber("Enter the first number: > ");
                var number2 = GetNumber("Enter the second number: > ");
                var result = GetResult(calc, number1, number2, operation);
                Console.WriteLine($"{number1} {operation} {number2} = {result}");
            }
            
            if (operation == 'p')
            {
                var selection = GetNumber("Enter prime number selection: >");
                var result = calc.GetPrimeNumber(selection);
                Console.WriteLine($"Prime number is {result}");
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private static int GetNumber(string message)
        {
            var isValid = false;
            while (!isValid)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                isValid = int.TryParse(input, out var number);
                if (isValid)
                    return number;

                Console.WriteLine("Please enter a valid number. Press ^C to quit.");
            }

            return -1;
        }

        private static char GetOperator()
        {
            var isValid = false;
            while (!isValid)
            {
                Console.Write("Please type the operator (/*+-p) > ");
                var input = Console.ReadKey();
                Console.WriteLine();
                var operation = input.KeyChar;
                if ("/*+-p".Contains(operation))
                {
                    isValid = true;
                    return operation;
                }

                Console.WriteLine("Please enter a valid operator (/, *, +, - or P). Press ^C to quit.");
            }

            return ' ';
        }

        private static float GetResult(SimpleCalculator calculator, int number1, int number2,
           char operation)
        {
            switch (operation)
            {
                case '+': return calculator.Add(number1, number2);
                case '-': return calculator.Subtract(number1, number2);
                case '*': return calculator.Multiply(number1, number2);
                case '/': return calculator.Divide(number1, number2);

                default:
                    throw new InvalidOperationException($"Invalid operation passed: {operation}");
            }
        }
    }
}
