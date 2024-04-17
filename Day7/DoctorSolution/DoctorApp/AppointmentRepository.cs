public class AppointmentRepository : IRepository<Appointment>
{
    private Dictionary<int, Appointment> _appointments = new Dictionary<int, Appointment>(); // Dictionary to store appointments, where key is the appointment's ID

    public void Add(Appointment entity)
    {
        _appointments.Add(entity.Id, entity);
    }

    public void Delete(Appointment entity)
    {
        _appointments.Remove(entity.Id);
    }

    public List<Appointment> GetAllAppointments()
    {
        return _appointments.Values.ToList();
    }
    public Appointment GetById(int id)
    {
        _appointments.TryGetValue(id, out Appointment appointment);
        return appointment;
    }

    public void Update(Appointment entity)
    {
        if (_appointments.ContainsKey(entity.Id))
        {
            _appointments[entity.Id] = entity;
        }
        else
        {
            Console.WriteLine($"Appointment with ID {entity.Id} not found.");
        }
    }
}
