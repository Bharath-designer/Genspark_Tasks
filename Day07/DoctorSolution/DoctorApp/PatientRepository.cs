public class PatientRepository : IRepository<Patient>
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();

    public void Add(Patient entity)
    {
        _patients.Add(entity.Id, entity);
    }

    public void Delete(Patient entity)
    {
        _patients.Remove(entity.Id);
    }

    public List<Patient> GetAllPatients()
    {
        return _patients.Values.ToList();
    }
    public Patient GetById(int id)
    {
        _patients.TryGetValue(id, out Patient patient);
        return patient;
    }

    public void Update(Patient entity)
    {
        if (_patients.ContainsKey(entity.Id))
        {
            _patients[entity.Id] = entity;
        }
        else
        {
            Console.WriteLine($"Patient with ID {entity.Id} not found.");
        }
    }
}