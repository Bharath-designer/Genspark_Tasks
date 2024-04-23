

using ClinicTestCaseModelLibrary;

namespace ClinicTestCaseBLLibrary
{
    public interface IDoctorService
    {
        Doctor Add(Doctor doctor);
        Doctor GetById(int id);
        List<Doctor> GetAll();
        Doctor Update(Doctor doctor);
        Doctor Delete(int id);

    }
}
