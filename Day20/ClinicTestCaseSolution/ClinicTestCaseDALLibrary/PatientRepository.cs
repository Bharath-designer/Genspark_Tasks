using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        public Patient Add(Patient entity)
        {
            ClinicAppContext context = new ClinicAppContext();

            if (entity == null)
            {
                return null;
            }

            try
            {
                context.Patients.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Patient> GetAll()
        {
            ClinicAppContext context = new ClinicAppContext();
            return context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            ClinicAppContext context = new ClinicAppContext();

            return context.Patients.Find(id);
        }

        public Patient Update(Patient entity)
        {

            ClinicAppContext context = new ClinicAppContext();
            var result = context.Patients.Find(entity.Id);
            if (result != null)
            {

                result.Name = entity.Name;
                result.Age = entity.Age;
                context.SaveChanges();
                return entity;
            }
            return null;

        }
        public Patient Delete(int id)
        {

            ClinicAppContext context = new ClinicAppContext();

            var result = context.Patients.Find(id);
            try
            {
                context.Patients.Remove(result);
                context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
