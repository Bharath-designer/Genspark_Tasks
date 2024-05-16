class AuthController
{
    public static User Login(List<User> users)
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        User currentUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (currentUser == null)
        {
            Console.WriteLine("Invalid username or password.");
        }
        else
        {
            Console.WriteLine($"Welcome, {currentUser.Username}!");
        }

        return currentUser;
    }

    public static void Register(List<User> users)
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        users.Add(new User(username, password, Role.User));
        Console.WriteLine("User registered successfully.");
    }
}