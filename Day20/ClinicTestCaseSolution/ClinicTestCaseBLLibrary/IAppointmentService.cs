
using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseBLLibrary
{
    public interface IAppointmentService
    {
        Appointment Add(Appointment appointment);
        Appointment GetById(int id);
        List<Appointment> GetAll();
        Appointment Update(Appointment appointment);
        Appointment Delete(int id);

    }
}
