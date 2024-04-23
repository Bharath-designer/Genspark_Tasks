

using ClinicTestCaseModelLibrary;

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

            if (_appointments.ContainsKey(entity.Id))
            {
                return null;
            }

            _appointments.Add(entity.Id, entity);
            return entity;
        }

        public List<Appointment> GetAll()
        {
            return new List<Appointment>(_appointments.Values);
        }

        public Appointment GetById(int id)
        {
            if (!_appointments.ContainsKey(id))
            {
                return null;
            }

            return _appointments[id];
        }

        public Appointment Update(Appointment entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (!_appointments.ContainsKey(entity.Id))
            {
                return null;
            }

            _appointments[entity.Id] = entity;
            return entity;
        }
        public Appointment Delete(int id)
        {
            if (!_appointments.ContainsKey(id))
            {
                return null;
            }

            Appointment deletedAppointment = _appointments[id];
            _appointments.Remove(id);
            return deletedAppointment;
        }

    }
}
