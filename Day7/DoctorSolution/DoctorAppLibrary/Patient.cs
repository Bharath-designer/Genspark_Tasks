﻿public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Patient(int id, string name, string email)
    {
        Id = id;   
        Name = name;
        Email = email;
    }
}