class Program
{
    static void Main(string[] args)
    {
        DepartmentRepository repository = new DepartmentRepository();

        while (true)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Show all departments");
            Console.WriteLine("2. Add Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ShowAllDepartments(repository);
                    break;
                case 2:
                    AddDepartment(repository);
                    break;
                case 3:
                    UpdateDepartment(repository);
                    break;
                case 4:
                    DeleteDepartment(repository);
                    break;
                case 5:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void ShowAllDepartments(DepartmentRepository repository)
    {
        Console.WriteLine("List of Departments:");
        foreach (var department in repository.GetAllDepartments())
        {
            Console.WriteLine($"ID: {department.Id}, Name: {department.Name}");
        }
    }

    static void AddDepartment(DepartmentRepository repository)
    {
        try
        {
            repository.AddDepartment();
            Console.WriteLine("Department added successfully.");
        }
        catch (DepartmentAlreadyFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void UpdateDepartment(DepartmentRepository repository)
    {
        Console.WriteLine("Enter Department ID to update:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Department Name:");
        string newName = Console.ReadLine();

        try
        {
            repository.UpdateDepartment(id, newName);
            Console.WriteLine("Department updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void DeleteDepartment(DepartmentRepository repository)
    {
        Console.WriteLine("Enter Department ID to delete:");
        int id = int.Parse(Console.ReadLine());

        try
        {
            repository.DeleteDepartment(id);
            Console.WriteLine("Department deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
