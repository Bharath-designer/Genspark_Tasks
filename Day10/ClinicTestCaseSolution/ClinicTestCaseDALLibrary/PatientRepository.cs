
using ClinicTestCaseModelLibrary;

namespace ClinicTestCaseDALLibrary
{
    public class PatientRepository: IRepository<int, Patient>
    {
        static Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();

        public Patient Add(Patient entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (_patients.ContainsKey(entity.Id))
            {
                return null;
            }

            _patients.Add(entity.Id, entity);
            return entity;
        }

        public List<Patient> GetAll()
        {
            return new List<Patient>(_patients.Values);
        }

        public Patient GetById(int id)
        {
            if (!_patients.ContainsKey(id))
            {
                return null;
            }

            return _patients[id];
        }

        public Patient Update(Patient entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (!_patients.ContainsKey(entity.Id))
            {
                return null;
            }

            _patients[entity.Id] = entity;
            return entity;
        }
        public Patient Delete(int id)
        {
            if (!_patients.ContainsKey(id))
            {
                return null;
            }

            Patient deletedPatient = _patients[id];
            _patients.Remove(id);
            return deletedPatient;
        }
    }
}
