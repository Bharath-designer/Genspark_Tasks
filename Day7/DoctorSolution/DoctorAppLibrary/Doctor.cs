﻿public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }

    public Doctor(int id, string name, string specilization)
    {
        Id = id;
        Name = name;    
        Specialization = specilization;
    }

}