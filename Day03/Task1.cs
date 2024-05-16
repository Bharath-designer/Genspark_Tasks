class Task1
{
    public static void Answer()
    {
        double num1, num2;
        Console.WriteLine("Enter numbers:");
        try
        {
            num1 = Convert.ToDouble(Console.ReadLine());
            num2 = Convert.ToDouble(Console.ReadLine());
        }
        catch (Exception)
        {
            throw new Exception("Please enter a valid Number!");
        }

        double addedNumbers = AddNumbers(num1, num2);
        Console.WriteLine($"The Sum of numbers is '{addedNumbers}'");

        double productOfNumbers = ProductOfNumbers(num1, num2);
        Console.WriteLine($"The Product of numbers is '{productOfNumbers}'");

        double divisionNumbers = DivideNumbers(num1, num2);
        Console.WriteLine($"The Division of numbers is '{divisionNumbers}'");

        double substractedNumbers = SubtractNumbers(num1, num2);
        Console.WriteLine($"The Substraction of numbers is '{substractedNumbers}'");

        double remainderOfNumbers = FindRemainder(num1, num2);
        Console.WriteLine($"The Remainder of numbers is '{remainderOfNumbers}'");

    }

    private static double AddNumbers(double num1, double num2)
    {
        return num1 + num2;
    }

    private static double ProductOfNumbers(double num1, double num2)
    {
        return num1 * num2;
    }

    private static double DivideNumbers(double num1, double num2)
    {
        return num1 / num2;
    }

    private static double SubtractNumbers(double num1, double num2)
    {
        return num1 - num2;
    }

    private static double FindRemainder(double num1, double num2)
    {
        return num1 % num2;
    }
}

