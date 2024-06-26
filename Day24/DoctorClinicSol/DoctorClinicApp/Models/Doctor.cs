﻿namespace DoctorClinicApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }

    public class DoctorCreateModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
    }

}
