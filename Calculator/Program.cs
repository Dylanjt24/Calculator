﻿using System.Text.RegularExpressions;

class Calculator
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

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Intitial calculator title
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Declare intial empty math variables
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            // Ask user for first math number
            Console.WriteLine("Type a number, then press Enter: ");
            numInput1 = Console.ReadLine();

            // Prompt for input until a number is input, save it in cleanNum1
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask user for second math number
            Console.WriteLine("Type a number, then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            // Prompt user to choose math operator
            Console.WriteLine("Choose an operator from the following list:\n" +
                "\ta - Add\n" +
                "\ts - Subtract\n" +
                "\tm - Multiply\n" +
                "\td - Divide\n" +
                "Your choice? ");

            string? op = Console.ReadLine();

            // Validate user input is not null and matches one of the available choices
            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                Console.WriteLine("Error: Unrecognizable input.");
            else
            {
                try
                {
                    // Display error if math operation is invalid, else display the result
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) Console.WriteLine("This operation will result in a methematical error.\n");
                    else Console.WriteLine("Your result: {0:0.##\n", result); // 0 = mandatory place, # = optional place
                }
                catch (Exception e)
                {
                    // Catch any other error that wasn't caught
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            // Wait for user response before closing
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Spacing for better styling
        }
        return;
    }
}