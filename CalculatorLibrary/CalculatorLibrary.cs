namespace CalculatorLibrary
{
    public class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not a number" to avoid division by 0 errors

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num2 - num1;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num1 != 0) result = num1 / num2;
                    break;
                // Return text displaying an incorrect option was input
                default:
                    break;
            }
            return result;
        }
    }
}
