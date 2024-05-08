using System;
using System.Collections.Generic;

namespace ClinicTestCaseDALLibrary.Model;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Specialization { get; set; }
}
