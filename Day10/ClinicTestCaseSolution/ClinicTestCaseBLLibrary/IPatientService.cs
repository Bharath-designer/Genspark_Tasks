using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicTestCaseModelLibrary;

namespace ClinicTestCaseBLLibrary
{
    public interface IPatientService
    {
        Patient Add(Patient patient);
        Patient GetById(int id);
        List<Patient> GetAll();
        Patient Update(Patient patient);
        Patient Delete(int id);

    }
}
