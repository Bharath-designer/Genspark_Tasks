class Program
{
    static DoctorRepository doctorRepository = new DoctorRepository();
    static PatientRepository patientRepository = new PatientRepository();
    static AppointmentRepository appointmentRepository = new AppointmentRepository();

    static void Main(string[] args)
    {
        CreateSampleData();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Doctor related operations");
            Console.WriteLine("2. Patient related operations");
            Console.WriteLine("3. Appointment related operations");
            Console.WriteLine("4. Exit");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    DoctorMenu();
                    break;
                case 2:
                    PatientMenu();
                    break;
                case 3:
                    AppointmentMenu();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void DoctorMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nDoctor related operations:");
            Console.WriteLine("1. Add a doctor");
            Console.WriteLine("2. Update a doctor");
            Console.WriteLine("3. Delete a doctor");
            Console.WriteLine("4. View all doctors");
            Console.WriteLine("5. Back");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter doctor details:");
                    int id = GetIntInput("Enter ID: ");
                    string name = GetStringInput("Enter name: ");
                    string specialization = GetStringInput("Enter specialization: ");
                    doctorRepository.Add(new Doctor(id, name, specialization));
                    Console.WriteLine("Doctor added successfully!");
                    break;
                case 2:
                    Console.WriteLine("Enter doctor ID to update:");
                    int updateId = GetIntInput("Enter ID: ");
                    Doctor doctorToUpdate = doctorRepository.GetById(updateId);
                    if (doctorToUpdate != null)
                    {
                        Console.WriteLine("Enter updated details:");
                        string updatedName = GetStringInput("Enter updated name: ");
                        string updatedSpecialization = GetStringInput("Enter updated specialization: ");
                        doctorToUpdate.Name = updatedName;
                        doctorToUpdate.Specialization = updatedSpecialization;
                        doctorRepository.Update(doctorToUpdate);
                        Console.WriteLine("Doctor updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Doctor not found!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter doctor ID to delete:");
                    int deleteId = GetIntInput("Enter ID: ");
                    Doctor doctorToDelete = doctorRepository.GetById(deleteId);
                    if (doctorToDelete != null)
                    {
                        doctorRepository.Delete(doctorToDelete);
                        Console.WriteLine("Doctor deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Doctor not found!");
                    }
                    break;
                case 4:
                    Console.WriteLine("List of all doctors:");
                    ListDoctors();
                    break;
                case 5:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void PatientMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nPatient related operations:");
            Console.WriteLine("1. Add a patient");
            Console.WriteLine("2. Update a patient");
            Console.WriteLine("3. Delete a patient");
            Console.WriteLine("4. View all patients");
            Console.WriteLine("5. Back");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter patient details:");
                    int id = GetIntInput("Enter ID: ");
                    string name = GetStringInput("Enter name: ");
                    string email = GetStringInput("Enter email: ");
                    patientRepository.Add(new Patient(id, name, email));
                    Console.WriteLine("Patient added successfully!");
                    break;
                case 2:
                    Console.WriteLine("Enter patient ID to update:");
                    int updateId = GetIntInput("Enter ID: ");
                    Patient patientToUpdate = patientRepository.GetById(updateId);
                    if (patientToUpdate != null)
                    {
                        Console.WriteLine("Enter updated details:");
                        string updatedName = GetStringInput("Enter updated name: ");
                        string updatedEmail = GetStringInput("Enter updated email: ");
                        patientToUpdate.Name = updatedName;
                        patientToUpdate.Email = updatedEmail;
                        patientRepository.Update(patientToUpdate);
                        Console.WriteLine("Patient updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Patient not found!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter patient ID to delete:");
                    int deleteId = GetIntInput("Enter ID: ");
                    Patient patientToDelete = patientRepository.GetById(deleteId);
                    if (patientToDelete != null)
                    {
                        patientRepository.Delete(patientToDelete);
                        Console.WriteLine("Patient deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Patient not found!");
                    }
                    break;
                case 4:
                    Console.WriteLine("List of all patients:");
                    ListPatients();
                    break;
                case 5:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void AppointmentMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nAppointment related operations:");
            Console.WriteLine("1. Schedule an appointment");
            Console.WriteLine("2. Cancel an appointment");
            Console.WriteLine("3. View all appointments");
            Console.WriteLine("4. Back");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter appointment details:");
                    int id = GetIntInput("Enter ID: ");
                    DateTime date = GetDateTimeInput("Enter date (yyyy-MM-dd): ");
                    int doctorId = GetIntInput("Enter doctor ID: ");
                    int patientId = GetIntInput("Enter patient ID: ");
                    appointmentRepository.Add(new Appointment(id, date, doctorId, patientId));
                    Console.WriteLine("Appointment scheduled successfully!");
                    break;
                case 2:
                    Console.WriteLine("Enter appointment ID to cancel:");
                    int cancelId = GetIntInput("Enter ID: ");
                    Appointment appointmentToCancel = appointmentRepository.GetById(cancelId);
                    if (appointmentToCancel != null)
                    {
                        appointmentRepository.Delete(appointmentToCancel);
                        Console.WriteLine("Appointment canceled successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Appointment not found!");
                    }
                    break;
                case 3:
                    Console.WriteLine("List of all appointments:");
                    ListAppointments();
                    break;
                case 4:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void ListPatients()
    {
        var patients = patientRepository.GetAllPatients();
        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Email: {patient.Email}");
        }
    }

    static void ListAppointments()
    {
        var appointments = appointmentRepository.GetAllAppointments();
        foreach (var appointment in appointments)
        {
            Console.WriteLine($"ID: {appointment.Id}, Date: {appointment.Date}, Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}");
        }
    }

    static DateTime GetDateTimeInput(string prompt)
    {
        DateTime result;
        bool validInput;
        do
        {
            Console.Write(prompt);
            validInput = DateTime.TryParse(Console.ReadLine(), out result);
            if (!validInput)
                Console.WriteLine("Invalid input. Please enter a valid date (yyyy-MM-dd).");
        } while (!validInput);
        return result;
    }


    static void ListDoctors()
    {
        var doctors = doctorRepository.GetAllDoctors();
        foreach (var doctor in doctors)
        {
            Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Specialization: {doctor.Specialization}");
        }
    }

    static int GetIntInput(string prompt)
    {
        int result;
        bool validInput;
        do
        {
            Console.Write(prompt);
            validInput = int.TryParse(Console.ReadLine(), out result);
            if (!validInput)
                Console.WriteLine("Invalid input. Please enter a valid integer.");
        } while (!validInput);
        return result;
    }

    static string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static void CreateSampleData()
    {
        doctorRepository.Add(new Doctor(1, "John", "General Physician"));
        doctorRepository.Add(new Doctor(2, "Smith", "Dermatologist"));

        patientRepository.Add(new Patient(1, "Alice", "alice@example.com"));
        patientRepository.Add(new Patient(2, "Bob", "bob@example.com"));

        appointmentRepository.Add(new Appointment(1, DateTime.Today, 1, 1));
        appointmentRepository.Add(new Appointment(2, DateTime.Today.AddDays(1), 2, 2));
    }
}
