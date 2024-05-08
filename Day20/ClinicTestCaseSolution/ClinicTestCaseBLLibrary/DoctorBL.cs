using ClinicTestCaseDALLibrary;
using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseBLLibrary
{
    public class DoctorBL: IDoctorService
    {
        private readonly IRepository<int, Doctor> doctorRepository;

        public DoctorBL(IRepository<int, Doctor> repo)
        {
            doctorRepository = repo;
        }

        public Doctor Add(Doctor doctor)
        {
            Doctor result = doctorRepository.Add(doctor);
            if (result != null)
            {
                return result;
            }
            throw new IdAlreadyFoundException("Can't add Doctor. Id already found");
        }

        public Doctor GetById(int id)
        {
            Doctor result = doctorRepository.GetById(id);
            if (result != null)
            {
                return result;
            }
            throw new IdNotFoundException($"Doctor with ID {id} not found");
        }

        public List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor Update(Doctor doctor)
        {
            Doctor result = doctorRepository.Update(doctor);
            if (result != null)
            {
                return result;
            }
            if (doctor != null)
                throw new IdNotFoundException($"Appointment with ID {doctor.Id} not found");
            else
                throw new IdNotFoundException("Can't find ID with 'null'");
        }

        public Doctor Delete(int id)
        {
            Doctor result = doctorRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new IdNotFoundException($"Doctor with ID {id} not found");
        }
    }
}
