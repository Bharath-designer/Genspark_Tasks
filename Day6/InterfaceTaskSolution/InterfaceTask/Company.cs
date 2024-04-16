class CTS : Employee
{
    public CTS(int empId, string name, string dept, double salary) : base(empId, name, dept, salary)
    {

    }
    
    public override double EmployeePF()
    {
        double employeePercentage = 0.12;
        double employerPercentage = 0.083;
        return (BasicSalary * employeePercentage) + (BasicSalary * employerPercentage);
    }

    public override double GratuityAmount(float serviceCompleted)
    {
        if (serviceCompleted < 5)
        {
            return 0;
        }
        else if (serviceCompleted <= 10)
        {
            return BasicSalary;
        }
        else if (serviceCompleted <= 20)
        {
            return 2 * BasicSalary;
        }
        else
        {
            return 3 * BasicSalary;
        }
    }

    public override string LeaveDetails()
    {
        string leaveDetails = "Leave Details for CTS is:\n" +
                              "1 day of Casual Leave per month\n" +
                              "12 days of Sick Leave per year\n" +
                              "10 days of Privilege Leave per year";
        return leaveDetails;
    }

}

class Accenture : Employee
{
    public Accenture(int empId, string name, string dept, double salary) : base(empId, name, dept, salary)
    {

    }

    public override double EmployeePF()
    {
        double employeePercentage = 0.12;
        double employerPercentage = 0.12;
        return (BasicSalary * employeePercentage) + (BasicSalary * employerPercentage);
    }

    public override double GratuityAmount(float serviceCompleted)
    {
        return 0;
    }

    public override string LeaveDetails()
    {
        string leaveDetails = "Leave Details for Accenture is:\n" +
                              "2 day of Casual Leave per month\n" +
                              "5 days of Sick Leave per year\n" +
                              "5 days of Privilege Leave per year";
        return leaveDetails;
    }

}