
public class DepartmentAlreadyFoundException : Exception
{
    public DepartmentAlreadyFoundException(string message) : base(message)
    {
    }
}

public class DepartmentRepository
{
    private Dictionary<int, Department> departments;

    public DepartmentRepository()
    {
        departments = new Dictionary<int, Department>();
    }

    public void AddDepartment()
    {
        Console.WriteLine("Enter Department ID:");
        int id = int.Parse(Console.ReadLine());

        if (departments.ContainsKey(id))
        {
            throw new DepartmentAlreadyFoundException("Department with this ID already exists.");
        }

        Console.WriteLine("Enter Department Name:");
        string name = Console.ReadLine();

        Department newDepartment = new Department(id, name);
        departments.Add(id, newDepartment);
    }

    public Department GetDepartmentById(int id)
    {
        if (departments.ContainsKey(id))
        {
            return departments[id];
        }
        else
        {
            throw new KeyNotFoundException("Department with this ID does not exist.");
        }
    }

    public List<Department> GetAllDepartments()
    {
        return new List<Department>(departments.Values);
    }

    public void UpdateDepartment(int id, string newName)
    {
        if (departments.ContainsKey(id))
        {
            departments[id].Name = newName;
        }
        else
        {
            throw new KeyNotFoundException("Department with this ID does not exist.");
        }
    }

    public void DeleteDepartment(int id)
    {
        if (departments.ContainsKey(id))
        {
            departments.Remove(id);
        }
        else
        {
            throw new KeyNotFoundException("Department with this ID does not exist.");
        }
    }
}