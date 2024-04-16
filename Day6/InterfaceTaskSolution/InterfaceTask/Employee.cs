abstract class Employee:GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public double BasicSalary { get; set; }

    public abstract double EmployeePF();
    
    public abstract double GratuityAmount(float serviceCompleted);

    public abstract string LeaveDetails();

    public Employee(int empId, string name,string dept, double salary)
    {
        EmpId = empId;
        Name = name;
        Dept = dept;
        BasicSalary = salary;
    }

    public override string ToString()
    {
        return $"Employee Id: {EmpId}, Name: {Name}, Dept: {Dept}, Basic Salary: {BasicSalary}";
    }
}
