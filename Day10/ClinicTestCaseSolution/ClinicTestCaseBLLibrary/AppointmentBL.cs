using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseModelLibrary;

public class AppointmentBL: IAppointmentService
{
    private readonly IRepository<int, Appointment> appointmentRepository;

    public AppointmentBL(IRepository<int, Appointment> repo)
    {
        appointmentRepository = repo;
    }

    public Appointment Add(Appointment appointment)
    {
        Appointment result = appointmentRepository.Add(appointment);
        if (result != null)
        {
            return result;
        }
        throw new IdAlreadyFoundException("Can't add Appointment. Id already found");
    }

    public Appointment GetById(int id)
    {
        Appointment result = appointmentRepository.GetById(id);
        if (result != null)
        {
            return result;
        }
        throw new IdNotFoundException($"Appointment with ID {id} not found");
    }

    public List<Appointment> GetAll()
    {
        return appointmentRepository.GetAll();
    }

    public Appointment Update(Appointment appointment)
    {
        Appointment result = appointmentRepository.Update(appointment);
        if (result != null)
        {
            return result;
        }
        if (appointment != null)
            throw new IdNotFoundException($"Appointment with ID {appointment.Id} not found");
        else
            throw new IdNotFoundException("Can't find ID with 'null'");
    }

    public Appointment Delete(int id)
    {
        Appointment result = appointmentRepository.Delete(id);
        if (result != null)
        {
            return result;
        }
        throw new IdNotFoundException($"Appointment with ID {id} not found");
    }
}