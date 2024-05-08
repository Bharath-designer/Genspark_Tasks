using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseDALLibrary.Model;


namespace ClinicTestCase
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<int, Doctor> doctorRepo = new DoctorRepository();
            IRepository<int, Patient> patientRepo = new PatientRepository();
            IRepository<int, Appointment> appointmentRepo = new AppointmentRepository();

            DoctorBL doctorBL = new DoctorBL(doctorRepo);
            PatientBL patientBL = new PatientBL(patientRepo);
            AppointmentBL appointmentBL = new AppointmentBL(appointmentRepo);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Patient");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DoctorMenu(doctorBL);
                            break;
                        case 2:
                            PatientMenu(patientBL);
                            break;
                        case 3:
                            AppointmentMenu(appointmentBL);
                            break;
                        case 4:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void DoctorMenu(DoctorBL doctorBL)
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Doctor Menu:");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Manage Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. Back to Main Menu");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Doctor Details:");
                            Console.WriteLine("Doctor ID:");
                            int doctorId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Doctor Name:");
                            string doctorName = Console.ReadLine();
                            Console.WriteLine("Specialization:");
                            string specialization = Console.ReadLine();

                            Doctor newDoctor = new Doctor() { Id = doctorId, Name = doctorName, Specialization = specialization};
                            try
                            {
                                doctorBL.Add(newDoctor);
                                Console.WriteLine("Doctor added successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error adding doctor: {ex.Message}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Doctor ID to manage:");
                            int doctorToManageId = int.Parse(Console.ReadLine());

                            try
                            {
                                Doctor doctorToManage = doctorBL.GetById(doctorToManageId);
                                Console.WriteLine($"Doctor ID: {doctorToManage.Id}");
                                Console.WriteLine($"Name: {doctorToManage.Name}");
                                Console.WriteLine($"Specialization: {doctorToManage.Specialization}");

                                Console.WriteLine("Do you want to update this doctor?");
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. No");
                                int updateChoice = int.Parse(Console.ReadLine());
                                if (updateChoice == 1)
                                {
                                    Console.WriteLine("Enter new Name:");
                                    string newName = Console.ReadLine();
                                    Console.WriteLine("Enter new Specialization:");
                                    string newSpecialization = Console.ReadLine();

                                    doctorToManage.Name = newName;
                                    doctorToManage.Specialization = newSpecialization;

                                    doctorBL.Update(doctorToManage);
                                    Console.WriteLine("Doctor updated successfully.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error managing doctor: {ex.Message}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Doctor ID to delete:");
                            int doctorToDeleteId = int.Parse(Console.ReadLine());
                            try
                            {
                                Doctor deletedDoctor = doctorBL.Delete(doctorToDeleteId);
                                Console.WriteLine($"Doctor with ID {deletedDoctor.Id} deleted successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deleting doctor: {ex.Message}");
                            }
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void PatientMenu(PatientBL patientBL)
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Patient Menu:");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Manage Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. Back to Main Menu");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Patient Details:");
                            Console.WriteLine("Patient ID:");
                            int patientId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Patient Name:");
                            string patientName = Console.ReadLine();
                            Console.WriteLine("Age:");
                            int age = int.Parse(Console.ReadLine());

                            Patient newPatient = new Patient() { Id = patientId, Name=patientName, Age=age };
                            try
                            {
                                patientBL.Add(newPatient);
                                Console.WriteLine("Patient added successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error adding patient: {ex.Message}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Patient ID to manage:");
                            int patientToManageId = int.Parse(Console.ReadLine());

                            try
                            {
                                Patient patientToManage = patientBL.GetById(patientToManageId);
                                Console.WriteLine($"Patient ID: {patientToManage.Id}");
                                Console.WriteLine($"Name: {patientToManage.Name}");
                                Console.WriteLine($"Age: {patientToManage.Age}");

                                Console.WriteLine("Do you want to update this patient?");
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. No");
                                int updateChoice = int.Parse(Console.ReadLine());
                                if (updateChoice == 1)
                                {
                                    Console.WriteLine("Enter new Name:");
                                    string newName = Console.ReadLine();
                                    Console.WriteLine("Enter new Age:");
                                    int newAge = int.Parse(Console.ReadLine());

                                    patientToManage.Name = newName;
                                    patientToManage.Age = newAge;

                                    patientBL.Update(patientToManage);
                                    Console.WriteLine("Patient updated successfully.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error managing patient: {ex.Message}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Patient ID to delete:");
                            int patientToDeleteId = int.Parse(Console.ReadLine());
                            try
                            {
                                Patient deletedPatient = patientBL.Delete(patientToDeleteId);
                                Console.WriteLine($"Patient with ID {deletedPatient.Id} deleted successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deleting patient: {ex.Message}");
                            }
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
        }

        static void AppointmentMenu(AppointmentBL appointmentBL)
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Appointment Menu:");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. Manage Appointment");
                Console.WriteLine("3. Delete Appointment");
                Console.WriteLine("4. Back to Main Menu");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Appointment Details:");
                            Console.WriteLine("Appointment ID:");
                            int appointmentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Date (yyyy-MM-dd HH:mm):");
                            DateTime appointmentDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);
                            Console.WriteLine("Doctor ID:");
                            int doctorId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Patient ID:");
                            int patientId = int.Parse(Console.ReadLine());

                            Appointment newAppointment = new Appointment() { Id=appointmentId,Date=appointmentDate, DoctorId=doctorId,PatientId=patientId };
                            try
                            {
                                appointmentBL.Add(newAppointment);
                                Console.WriteLine("Appointment added successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error adding appointment: {ex.Message}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Appointment ID to manage:");
                            int appointmentToManageId = int.Parse(Console.ReadLine());

                            try
                            {
                                Appointment appointmentToManage = appointmentBL.GetById(appointmentToManageId);
                                Console.WriteLine($"Appointment ID: {appointmentToManage.Id}");
                                Console.WriteLine($"Date: {appointmentToManage.Date}");
                                Console.WriteLine($"Doctor ID: {appointmentToManage.DoctorId}");
                                Console.WriteLine($"Patient ID: {appointmentToManage.PatientId}");

                                Console.WriteLine("Do you want to update this appointment?");
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. No");
                                int updateChoice = int.Parse(Console.ReadLine());
                                if (updateChoice == 1)
                                {
                                    Console.WriteLine("Enter new Date (yyyy-MM-dd HH:mm):");
                                    DateTime newDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);
                                    Console.WriteLine("Enter new Doctor ID:");
                                    int newDoctorId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter new Patient ID:");
                                    int newPatientId = int.Parse(Console.ReadLine());

                                    appointmentToManage.Date = newDate;
                                    appointmentToManage.DoctorId = newDoctorId;
                                    appointmentToManage.PatientId = newPatientId;

                                    appointmentBL.Update(appointmentToManage);
                                    Console.WriteLine("Appointment updated successfully.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error managing appointment: {ex.Message}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Appointment ID to delete:");
                            int appointmentToDeleteId = int.Parse(Console.ReadLine());
                            try
                            {
                                Appointment deletedAppointment = appointmentBL.Delete(appointmentToDeleteId);
                                Console.WriteLine($"Appointment with ID {deletedAppointment.Id} deleted successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deleting appointment: {ex.Message}");
                            }
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

    }
}
