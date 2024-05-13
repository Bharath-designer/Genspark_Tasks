using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {

        static Employee currentUser = null;
        static RequestBL requestBL = new RequestBL();
        static SolutionBL solutionBL = new SolutionBL();
        static FeedbackBL feedbackBL = new FeedbackBL();

        static async Task Main(string[] args)
        {

            while(true)
            {
                if (currentUser == null)
                {
                    currentUser = await GetLoginDetails();
                    if (currentUser == null)
                    {
                        Console.WriteLine("Invalid Username or password");
                    } else
                    {
                        Console.WriteLine("Welcome, " + currentUser.Name);
                    }
                } else
                {
                    if (currentUser.Role == "Admin")
                    {
                        await DisplayAdminMenu();
                    } else
                    {
                        DisplayUserRole();
                    }
                }
                Console.WriteLine();
            }
        }

        static async Task<Employee> GetLoginDetails()
        {
            EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            Console.WriteLine("Enter Username:");
            int username = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            return await employeeLoginBL.Login(username, password);
        }

        static async Task DisplayAdminMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status (All Requests)");
            Console.WriteLine("3. View Solutions (All Solutions)");
            Console.WriteLine("4. Give Feedback (Only for requests raised by them)");
            Console.WriteLine("5. Provide Solution");
            Console.WriteLine("6. Mark Request as Closed");
            Console.WriteLine("7. View Feedbacks (Only feedbacks given to them)");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Request Message:");
                    string message = Console.ReadLine();
                    await requestBL.CreateRequest(message, currentUser.Id);
                    Console.WriteLine("Request Created Successfully.");
                    break;
                case "2":
                    var requests = await requestBL.GetAllRequest();
                    for( var i = 0; i < requests.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + requests[i]);
                    }
                    break;
                case "3":
                    var solutions = await solutionBL.GetAllSolutions();
                    for (var i = 0; i < solutions.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + solutions[i]);
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter Solution Id:");
                    int solutionId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Feedback Description:");
                    string remark = Console.ReadLine();
                    await feedbackBL.CreateFeedback(solutionId, remark, currentUser.Id);
                    Console.WriteLine("Feedback Created Successfully.");
                    break;
                case "5":
                    Console.WriteLine("Enter Request Id:");
                    int requestId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Solution Description:");
                    string description = Console.ReadLine();
                    await solutionBL.CreateSolution(requestId, description, currentUser.Id);
                    Console.WriteLine("Solution Created Successfully.");
                    break;
                case "6":
                    Console.WriteLine("Enter Request Id:");
                    int requestIdForCLoseRequest = int.Parse(Console.ReadLine());
                    await requestBL.CloseRequest(requestIdForCLoseRequest, currentUser.Id);
                    Console.WriteLine("Request closed successfully");
                    break;
                case "7":
                    var feedbacks = await feedbackBL.GetAllFeedbacks();
                    for (var i = 0; i < feedbacks.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + feedbacks[i]);
                    }
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }

        static async Task DisplayUserRole()
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Request Message:");
                    string message = Console.ReadLine();
                    await requestBL.CreateRequest(message, currentUser.Id);
                    Console.WriteLine("Request Created Successfully.");
                    break;
                case "2":
                    var requests = await requestBL.GetAllRequest(currentUser.Id);
                    for (var i = 0; i < requests.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + requests[i]);
                    }
                    break;
                case "3":
                    var solutions = await solutionBL.GetAllSolutions(currentUser.Id);
                    for (var i = 0; i < solutions.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + solutions[i]);
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter Solution Id:");
                    int solutionId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Feedback Description:");
                    string remark = Console.ReadLine();
                    await feedbackBL.CreateFeedback(solutionId, remark, currentUser.Id);
                    Console.WriteLine("Feedback Created Successfully.");
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }   

    }
}
