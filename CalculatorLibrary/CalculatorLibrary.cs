using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.json"); // StreamWriter implements a TextWriter for writing characters to a stream in a particular encoding
            logFile.AutoFlush = true; // Calls Flush() after every write, which flushes the output buffer and causes buffered data to be written
            writer = new JsonTextWriter(logFile); // Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data
            writer.Formatting = Formatting.Indented; // Causes child objects to be indented
            writer.WriteStartObject(); // Writes a JSON start object ({)
            writer.WritePropertyName("Operations"); // Writes the property name of the name/value pair
            writer.WriteStartArray(); // Writes a JSON start array ([)
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not a number" to avoid division by 0 errors
            writer.WriteStartObject(); // Writes a JSON start object ({)
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");


            // Switch statement to do the math
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num2 - num1;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // Make sure divisor is non-zero
                    if (num2 != 0)
                        result = num1 / num2;
                    writer.WriteValue("Divide");
                    break;
                // Return text displaying an incorrect option was input
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject(); // Writes a JSON end object (})

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray(); // Writes a JSON end array (])
            writer.WriteEndObject(); // Writes a JSON end object (})
            writer.Close(); // Closes the JSON stream
        }
    }
}
