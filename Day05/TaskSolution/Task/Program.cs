namespace Task
{
    internal class Company
    {
        static List<Employee> employeeList = new List<Employee>();

        static void Main(string[] args)
        {
            Company.PrintOptions();
            int userOption;
            Console.WriteLine("Please select number to perform operation");
            while (int.TryParse(Console.ReadLine(), out userOption))
            {
                Console.WriteLine();
                switch (userOption)
                {
                    case 1:
                        Company.createEmployee();
                        break;
                    case 2:
                        Company.PrintAllEmployees();
                        break;
                    case 3:
                        int employeeId;
                        try
                        {
                            Console.WriteLine("Enter employee ID:");
                            employeeId = Convert.ToInt32(Console.ReadLine());
                            Company.PrintEmployeeById(employeeId);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter a valid number of employee!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Name to search:");
                        string employeeName = Console.ReadLine();
                        Company.SearchByName(employeeName);
                        break;
                    case 5:
                        int empId;
                        try
                        {
                            Console.WriteLine("Enter employee ID:");
                            empId = Convert.ToInt32(Console.ReadLine());
                            Company.UpdateNameById(empId);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter a valid number of employee!");
                        }
                        break;
                    case 6:
                        int employeeIdToBeDeleted;
                        try
                        {
                            Console.WriteLine("Enter employee ID:");
                            employeeIdToBeDeleted = Convert.ToInt32(Console.ReadLine());
                            Company.DeleteById(employeeIdToBeDeleted);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter a valid number of employee!");
                        }
                        break;


                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("-------------------");
                Company.PrintOptions();
                Console.WriteLine("Please select number to perform operation. Enter any alphabets to exit.");


            }

            Console.WriteLine("Program exited");

        }

        static void PrintOptions()
        {
            Console.WriteLine("1. Create Employees");
            Console.WriteLine("2. Print all Employees");
            Console.WriteLine("3. Print Employee by ID");
            Console.WriteLine("4. Search Employee by Name");
            Console.WriteLine("5. Update Name by ID");
            Console.WriteLine("6. Delete Employee by ID");
        }
        static void createEmployee()
        {
            while (true)
            {
                Employee employee = new Employee();
                Console.WriteLine("Please Enter Employee details to create Employee");
                try
                {
                    Console.WriteLine("Enter employee id:");
                    employee.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter employee name:");
                    employee.Name = Console.ReadLine()!;
                    Console.WriteLine("Enter employee salary:");
                    employee.Salary = Convert.ToSingle(Console.ReadLine());
                    employeeList.Add(employee);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter valid input!");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("Employee created successfully!");
                Console.WriteLine();
                Console.WriteLine("Do you want to continue creating employees? (y/n)");
                string userConfirmation = Console.ReadLine()!;
                while (userConfirmation != "y" && userConfirmation != "n")
                {
                    Console.WriteLine("Enter only 'y' or 'n'");
                    userConfirmation = Console.ReadLine()!;
                }

                if (userConfirmation == "n")
                {
                    break;
                }
            }

        }
        static void PrintAllEmployees()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No Employee is found. Please create employees");
            }
            foreach (Employee employee in employeeList)
            {
                Console.WriteLine($"Employee Id: {employee.Id}, Name: {employee.Name}, Salary: {employee.Salary}");
            }
        }

        static Employee getEmployeeById(int id)
        {
            foreach (Employee employee in employeeList)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        static void PrintEmployeeById(int id)
        {
            Employee employee = Company.getEmployeeById(id);

            if (employee == null)
                Console.WriteLine("Employee with the given ID not found");
            else
                Console.WriteLine($"Employee Id: {employee.Id}, Name: {employee.Name}, Salary: {employee.Salary}");

        }

        static void SearchByName(string name)
        {
            bool foundEmployee = false;
            foreach (Employee employee in employeeList)
            {
                if (employee.Name == name)
                {
                    foundEmployee = true;
                    Console.WriteLine($"Employee Id: {employee.Id}, Name: {employee.Name}, Salary: {employee.Salary}");
                }
            }
            if (!foundEmployee)
                Console.WriteLine("No Employees found with given Name.");

        }

        static void UpdateNameById(int id)
        {
            Employee employee = Company.getEmployeeById(id);

            if (employee == null)
                Console.WriteLine("Employee with the given ID not found");
            else
            {
                Console.WriteLine("Enter the name to be updated:");
                string name = Console.ReadLine()!;
                employee.Name = name;
                Console.WriteLine("Name Updated for the given Employee Id");
            }

        }

        static void DeleteById(int id)
        {
            int empIndex = employeeList.FindIndex(employee => employee.Id == id);
            if (empIndex == -1)
                Console.WriteLine("No employee found with the given Id.");
            else
            {
                employeeList.RemoveAt(empIndex);
                Console.WriteLine("Employee removed successfully!");
            }
        }
    }
}
