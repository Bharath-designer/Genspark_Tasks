
using ClinicTestCaseDALLibrary;
using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseBLLibrary
{
    public class PatientBL: IPatientService
    {
        IRepository<int, Patient> patientRepository;

        public PatientBL(IRepository<int, Patient> repo)
        {
            patientRepository = repo;
        }

        public Patient Add(Patient patient)
        {
            Patient result = patientRepository.Add(patient);
            if (result != null)
            {
                return result;
            }
            throw new IdAlreadyFoundException("Can't add Patient. Id already found");
        }
        public Patient GetById(int id)
        {
            Patient result = patientRepository.GetById(id);
            if (result != null)
            {
                return result;
            }
            throw new IdNotFoundException($"Patient with ID {id} not found");
        }

        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Patient Update(Patient patient)
        {
            Patient result = patientRepository.Update(patient);
            if (result != null)
            {
                return result;
            }
            if (patient != null)
                throw new IdNotFoundException($"Appointment with ID {patient.Id} not found");
            else
                throw new IdNotFoundException("Can't find ID with 'null'");
        }

        public Patient Delete(int id)
        {
            Patient result = patientRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new IdNotFoundException($"Patient with ID {id} not found");
        }

    }
}
