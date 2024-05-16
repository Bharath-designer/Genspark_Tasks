class Task5 {
    public static void Answer() {
        const string correctUsername = "ABC";
        const string correctPassword = "123";
        int attemptsRemaining = 3;

        while (attemptsRemaining > 0)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            if (username == correctUsername && password == correctPassword)
            {
                Console.WriteLine("Login successful!");
                break;
            }
            else
            {
                Console.WriteLine("Incorrect username or password. Please try again.");
                attemptsRemaining--;

                if (attemptsRemaining == 0)
                {
                    Console.WriteLine("You have exceeded the number of attempts. Access denied.");
                }
                else
                {
                    Console.WriteLine($"You have {attemptsRemaining} attempt(s) remaining.");
                }
            }
        }

    }
}