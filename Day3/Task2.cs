class Task2
{
    public static void Answer()
    {
        int max = int.MinValue;
        Console.WriteLine("Enter a series of numbers. Enter a negative number to stop.");

        while (true)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < 0)
            {
                break;
            }

            if (num > max)
            {
                max = num; 
            }
        }

        if (max == int.MinValue)
        {
            Console.WriteLine("No numbers were entered.");
        }
        else
        {
            Console.WriteLine($"The greatest number entered is: {max}");
        }

    }
}

