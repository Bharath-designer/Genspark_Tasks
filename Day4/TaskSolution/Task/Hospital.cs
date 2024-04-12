namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            Doctor doctor1  = new Doctor("1001", "John", 30, 5, "MD", "Cardiology");
            Doctor doctor2  = new Doctor("1002", "David", 42, 14, "MS", "Anesthesiology");
            Doctor doctor3  = new Doctor("1003", "Michael Davis", 45, 18, "MBBS", "Neurology");
            Doctor doctor4  = new Doctor("1004", "Sarah Wilson", 38, 12, "MD", "Nephrology");
            Doctor doctor5  = new Doctor("1005", "Jennifer Taylor", 40, 13, "MS", "Cardiology");

            Doctor[] doctorsArray = new Doctor[] { doctor1, doctor2, doctor3, doctor4, doctor5 };

           PrintDoctorArray(doctorsArray);

            Console.WriteLine();
            Console.WriteLine("Write the required speciality");
            GetDoctorBySpeciality(doctorsArray);

        }

        static void PrintDoctorArray(Doctor[] doctorsArray)
        {
            Console.WriteLine("Available list of Doctors are below");
            foreach (Doctor doctor in doctorsArray)
            {
                Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Age: {doctor.Age}, Experience: {doctor.Experience}, Qualification: {doctor.Qualification}, Speciality: {doctor.Speciality}");
            }

        }

        static void GetDoctorBySpeciality(Doctor[] doctorsArray)
        {
            string requiredSpeciality = Console.ReadLine()!;
            List<Doctor> doctors = new List<Doctor>();
            foreach ( Doctor doctor in doctorsArray)
            {
                if (doctor.Speciality.ToLower() == requiredSpeciality.ToLower())
                {
                    doctors.Add(doctor);
                }
            }

            if (doctors.Count > 0)
            {
                Console.WriteLine("The doctors with the given speciality are below");
                foreach (Doctor doctor in doctors)
                {
                    Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}");
                }
            } else
            {
                Console.WriteLine("No doctors is found with the given speciality!");
            }
            
        }
    }
}
