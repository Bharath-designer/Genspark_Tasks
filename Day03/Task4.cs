class Task4 {
    public static void Answer() {
        Console.WriteLine("Please enter your name:");
        string userName = Console.ReadLine()!;

        int nameLength = userName.Length;

        Console.WriteLine($"The length of your name is: {nameLength}");

    }
}