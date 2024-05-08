

using ClinicTestCaseDALLibrary.Model;

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
            ClinicAppContext context = new ClinicAppContext();
            try
            {
            context.Doctors.Add(entity);
            context.SaveChanges();
            return entity;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public List<Doctor> GetAll()
        {
            ClinicAppContext context = new ClinicAppContext();

            return context.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            ClinicAppContext context = new ClinicAppContext();
            
            return context.Doctors.Find(id);
        }

        public Doctor Update(Doctor entity)
        {
            ClinicAppContext context = new ClinicAppContext();
            var result = context.Doctors.Find(entity.Id);
            if (result != null)
            {

                result.Name = entity.Name;
                result.Specialization = entity.Specialization;
                context.SaveChanges();
                return entity;
            }
            return null;
        }
        public Doctor Delete(int id)
        {
            ClinicAppContext context = new ClinicAppContext();
            try
            {
            var result = context.Doctors.Find(id);
            context.Doctors.Remove(result);
            context.SaveChanges();
            return result;

            }catch (Exception ex)
            {
                return null;
            }
        }

    }
}
