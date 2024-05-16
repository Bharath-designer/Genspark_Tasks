class Doctor {
    string id;
    string name;
    int age;
    int experience;
    string qualification;
    string speciality;

    public string Id
    {
        get => id; 
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public int Experience
    {
        get => experience;
        set => experience = value;
    }

    public string Qualification
    {
        get => qualification;
        set => qualification = value;
    }

    public string Speciality
    {
        get => speciality;
        set => speciality = value;
    }
    public Doctor(string id, string name, int age, int experience, string qualification, string speciality)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.experience = experience;
        this.qualification = qualification;
        this.speciality = speciality;
    }   

}