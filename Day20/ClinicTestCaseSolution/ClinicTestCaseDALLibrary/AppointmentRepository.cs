

using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        static Dictionary<int, Appointment> _appointments = new Dictionary<int, Appointment>();

        public Appointment Add(Appointment entity)
        {
            if (entity == null)
            {
                return null;
            }

            ClinicAppContext context = new ClinicAppContext();
            try
            {
            context.Appointments.Add(entity);
            context.SaveChanges();
            return entity; ;

            } catch (Exception ex)
            {
                return null;
            }
        }

        public List<Appointment> GetAll()
        {
            ClinicAppContext context = new ClinicAppContext();

            return context.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            ClinicAppContext context = new ClinicAppContext();

            return context.Appointments.Find(id);
        }

        public Appointment Update(Appointment entity)
        {
            if (entity == null)
            {
                return null;
            }

            ClinicAppContext context = new ClinicAppContext();
            var result = context.Appointments.Find(entity.Id);
            if (result != null)
            {

                result.Date = entity.Date;
                result.PatientId = entity.PatientId;
                result.DoctorId = entity.DoctorId;
                context.SaveChanges();
                return entity;
            }
            return null;
        }
        public Appointment Delete(int id)
        {

            ClinicAppContext context = new ClinicAppContext();
            try
            {

            var result = context.Appointments.Find(id);
            
            context.Appointments.Remove(result);
            context.SaveChanges();
            return result;
            }catch (Exception ex)
            {
                return null;
            }
        }

    }
}
