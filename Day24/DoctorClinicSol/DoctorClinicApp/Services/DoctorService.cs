using DoctorClinicApp.Exceptions;
using DoctorClinicApp.Models;
using DoctorClinicApp.Repositories;

namespace DoctorClinicApp.Services
{
    public class DoctorService
    {
        private readonly IRepository<Doctor, int> _repository;

        public DoctorService(IRepository<Doctor, int> repo)
        {
            _repository = repo;
        }

        public async Task AddDoctor(Doctor entity)
        {
            await _repository.Add(entity);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _repository.GetAll();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _repository.GetById(id);

        }

        public async Task UpdateDoctorSpecialization(int id, string specialization)
        {
            Doctor doctor = await _repository.GetById(id);
            if (doctor == null)
            {
                throw new DoctorNotFountException("Doctor with given id not found");
            }
            doctor.Specialization = specialization;
            await _repository.Update(doctor);
        }
    }
}
