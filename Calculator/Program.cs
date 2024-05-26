int num1 = 0; int num2 = 0;

Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

// Get first num from user
Console.WriteLine("Type a number, then press Enter:");
num1 = Convert.ToInt32(Console.ReadLine());

// Get second num from user
Console.WriteLine("Type another number, then press Enter:");
num2 = Convert.ToInt32(Console.ReadLine());

// Ask which math operation they want to use
Console.Write("Choose an option from the following list:\n" +
    "\ta - Add\n" +
    "\ts - Subtract\n" +
    "\tm - Multiply\n" +
    "\td - Divide\n" +
    "Your option?\n");

// Switch for math result based on user response
switch (Console.ReadLine())
{
    case "a":
        Console.WriteLine($"Your result: {num1} + {num2} = {num1 + num2}");
        break;
    case "s":
        Console.WriteLine($"Your result: {num1} - {num2} = {num1 - num2}");
        break;
    case "m":
        Console.WriteLine($"Your result: {num1} * {num2} = {num1 * num2}");
        break;
    case "d":
        Console.WriteLine($"Your result: {num1} / {num2} = {num1 / num2}");
        break;
}

// Wait for user to respond before closing
Console.WriteLine("Press any key to close the Calculator console app...");
Console.ReadKey();