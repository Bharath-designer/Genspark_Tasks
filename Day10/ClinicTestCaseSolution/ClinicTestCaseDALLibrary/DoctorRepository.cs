

using ClinicTestCaseModelLibrary;

namespace ClinicTestCaseDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        static Dictionary<int, Doctor> _doctors = new Dictionary<int, Doctor>();

        public Doctor Add(Doctor entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (_doctors.ContainsKey(entity.Id))
            {
                return null;
            }

            _doctors.Add(entity.Id, entity);
            return entity;
        }

        public List<Doctor> GetAll()
        {
            return new List<Doctor>(_doctors.Values);
        }

        public Doctor GetById(int id)
        {
            if (!_doctors.ContainsKey(id))
            {
                return null;
            }

            return _doctors[id];
        }

        public Doctor Update(Doctor entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (!_doctors.ContainsKey(entity.Id))
            {
                return null;
            }

            _doctors[entity.Id] = entity;
            return entity;
        }
        public Doctor Delete(int id)
        {
            if (!_doctors.ContainsKey(id))
            {
                return null;
            }

            Doctor deletedDoctor = _doctors[id];
            _doctors.Remove(id);
            return deletedDoctor;
        }

    }
}
