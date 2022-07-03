using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Logger : ILogger
    {
        public void Log(string result)
        {
            // Write our calculator method(s) return result to debugger
            Console.WriteLine($"Result: {result}");
        }
    }
}
