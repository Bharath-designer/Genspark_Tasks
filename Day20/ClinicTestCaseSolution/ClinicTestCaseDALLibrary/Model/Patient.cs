using System;
using System.Collections.Generic;

namespace ClinicTestCaseDALLibrary.Model;

public partial class Patient
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }
}
