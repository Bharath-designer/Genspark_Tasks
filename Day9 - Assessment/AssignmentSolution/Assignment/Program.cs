// use username 'admin' and password 'admin' to login as Admin User.

class Program
{
    static List<Quiz> quizzes = new List<Quiz>();
    static List<User> users = new List<User>();
    static User? currentUser = null;

    static AdminMenu adminMenu = new AdminMenu(quizzes);
    static UserMenu userMenu = new UserMenu(quizzes);

    static void Main(string[] args)
    {
        users.Add(new User("admin", "admin", Role.Admin));

        bool isExited = false;
        while (!isExited)
        {
            if (currentUser == null)
            {
                Console.WriteLine("-----------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string selectedOption = Console.ReadLine();
                switch (selectedOption)
                {
                    case "1":
                        currentUser = AuthController.Login(users);
                        break;
                    case "2":
                        AuthController.Register(users);
                        break;
                    case "3":
                        isExited = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                if (currentUser.Role == Role.Admin)
                {
                    AdminMenu();
                }
                else
                {
                    UserMenu();
                }
            }
        }
    }

    static void AdminMenu()
    {
        Console.WriteLine();
        Console.WriteLine("-----Admin Menu------");
        Console.WriteLine("1. Create Quiz");
        Console.WriteLine("2. Manage Quizzes");
        Console.WriteLine("3. Delete Quiz");
        Console.WriteLine("4. Logout");
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                adminMenu.CreateQuiz();
                break;
            case "2":
                adminMenu.ManageQuizzes();
                break;
            case "3":
                adminMenu.DeleteQuiz();
                break;
            case "4":
                currentUser = null;
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void UserMenu()
    {
        Console.WriteLine("-----User Menu-----");
        Console.WriteLine("1. Take Quiz");
        Console.WriteLine("2. Logout");
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                userMenu.TakeQuiz();
                break;
            case "2":
                currentUser = null;
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

}
