class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------CTS Employee---------");
        Employee cts = new CTS(101, "Ram", "Development", 70000);
        Console.WriteLine(cts);
        Console.WriteLine($"Employee PF: {cts.EmployeePF()}");
        Console.WriteLine($"Gratuity Amount: {cts.GratuityAmount(15)}");
        Console.WriteLine($"Leave Details: {cts.LeaveDetails()}");
        Console.WriteLine("------------------------------");
        Console.WriteLine();

        Console.WriteLine("------Accenture Employee-----------");
        Employee accenture = new Accenture(101, "Somu", "Tester", 60000);
        Console.WriteLine(accenture);
        Console.WriteLine($"Employee PF: {accenture.EmployeePF()}");
        double gratuityAccenture = accenture.GratuityAmount(15);
        Console.WriteLine("Gratuity Amount: " + (gratuityAccenture == 0 ? "Not applicable" : gratuityAccenture));
        Console.WriteLine($"Leave Details: {accenture.LeaveDetails()}");
        Console.WriteLine("------------------------------");

    }
}