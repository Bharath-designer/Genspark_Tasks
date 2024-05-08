using System;
using System.Collections.Generic;

namespace ClinicTestCaseDALLibrary.Model;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }
}
