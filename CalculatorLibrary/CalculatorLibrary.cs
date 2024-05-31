using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.log"); // StreamWriter implements a TextWriter for writing characters to a stream in a particular encoding
            Trace.Listeners.Add(new TextWriterTraceListener(logFile)); // Adds a TraceListener and directs tracing/debugging to the created logFile
            Trace.AutoFlush = true; // Calls Flush() after every write, which flushes the output buffer and causes buffered data to be written to the Listeners
            Trace.WriteLine("Starting Calculator Log"); // Writes the value of the object's ToString() method to the Listeners
            Trace.WriteLine(String.Format($"Started {System.DateTime.Now.ToString()}"));
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not a number" to avoid division by 0 errors

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    Trace.WriteLine($"{num1} + {num2} = {result}");
                    break;
                case "s":
                    result = num2 - num1;
                    Trace.WriteLine($"{num1} - {num2} = {result}");
                    break;
                case "m":
                    result = num1 * num2;
                    Trace.WriteLine($"{num1} * {num2} = {result}");
                    break;
                case "d":
                    // Make sure divisor is non-zero
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Trace.WriteLine($"{num1} / {num2} = {result}");
                    }
                    break;
                // Return text displaying an incorrect option was input
                default:
                    break;
            }
            return result;
        }
    }
}
