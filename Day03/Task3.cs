class Task3 {
    public static void Answer() {
        int sum = 0;
        int count = 0;

        Console.WriteLine("Enter a series of numbers. Enter a negative number to stop.");

        while (true)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < 0)
            {
                break;
            }

            if (num % 7 == 0)
            {
                sum += num; 
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No numbers divisible by 7 were entered.");
        }
        else
        {
            double average = (double)sum / count;
            Console.WriteLine($"The average of numbers divisible by 7 is: {average}");
        }
    }
}