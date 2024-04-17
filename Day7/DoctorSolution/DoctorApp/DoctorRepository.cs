public class DoctorRepository : IRepository<Doctor>
{
    private Dictionary<int, Doctor> _doctors = new Dictionary<int, Doctor>();

    public void Add(Doctor entity)
    {
        _doctors.Add(entity.Id, entity);
    }

    public void Delete(Doctor entity)
    {
        _doctors.Remove(entity.Id);
    }

    public List<Doctor> GetAllDoctors()
    {
        return _doctors.Values.ToList();
    }
    public Doctor GetById(int id)
    {
        _doctors.TryGetValue(id, out Doctor doctor);
        return doctor;
    }

    public void Update(Doctor entity)
    {
        if (_doctors.ContainsKey(entity.Id))
        {
            _doctors[entity.Id] = entity;
        }
        else
        {
            Console.WriteLine($"Doctor with ID {entity.Id} not found.");
        }
    }
}
