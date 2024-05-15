using DoctorClinicApp.Exceptions;
using DoctorClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApp.Repositories
{
    public class DoctorRepository : IRepository<Doctor, int>
    {
        private readonly DoctorClinicContext _context;

        public DoctorRepository(DoctorClinicContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetById(int id)
        {
            Doctor doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new DoctorNotFountException("Doctor with given Id not found");
            }
            return doctor;
        }

        public async Task Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Doctor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Doctor doctor = await GetById(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }


    }
}
