

using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseDALLibrary.Model;

namespace ClinicTestCaseTestFiles
{
    public class AppointmentTest
    {
        IAppointmentService appointmentService;

        [SetUp]
        public void Setup()
        {
            IRepository<int, Appointment> repo = new AppointmentRepository();
            appointmentService = new AppointmentBL(repo);
        }

        [Test]
        public void AddSuccessTest()
        {
            Appointment appointment = new Appointment() { Id=1, Date= DateTime.Now, DoctorId =1,PatientId= 1 };

            Appointment result = appointmentService.Add(appointment);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
            Appointment appointment = new Appointment() { Id = 2, Date = DateTime.Now, DoctorId = 2, PatientId = 2 };
            appointmentService.Add(appointment);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Appointment result = appointmentService.Add(appointment);
            });
        }

        [Test]
        public void AddFailTest2()
        {

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Appointment result = appointmentService.Add(null);
            });
        }

        [Test]
        public void GetByIdSuccessTest()
        {
            Appointment appointment = new Appointment() { Id = 3, Date = DateTime.Now, DoctorId = 3, PatientId = 3 };
            appointmentService.Add(appointment);

            Appointment result = appointmentService.GetById(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void GetByIdFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Appointment result = appointmentService.GetById(999);
            });
        }

        [Test]
        public void GetAllSuccessTest()
        {

            var allAppointments = appointmentService.GetAll();

            Assert.IsNotNull(allAppointments);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            Appointment appointment = new Appointment() { Id = 4, Date = DateTime.Now, DoctorId = 4, PatientId = 4 };
            appointmentService.Add(appointment);

            appointment.Date = DateTime.Now.AddDays(1);
            Appointment updatedAppointment = appointmentService.Update(appointment);

            Assert.IsNotNull(updatedAppointment);
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, updatedAppointment.Date);
        }

        [Test]
        public void UpdateFailTest()
        {
            Appointment appointment = new Appointment() { Id = 5, Date = DateTime.Now, DoctorId = 5, PatientId = 5 };

            Assert.Throws<IdNotFoundException>(() =>
            {
                Appointment result = appointmentService.Update(appointment);
            });
        }

        [Test]
        public void UpdateFailTest2()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                appointmentService.Update(null);
            });
        }

        [Test]
        public void DeleteSuccessTest()
        {
            Appointment appointment = new Appointment() { Id = 6, Date = DateTime.Now, DoctorId = 6, PatientId = 6 };
            appointmentService.Add(appointment);

            Appointment deletedAppointment = appointmentService.Delete(6);

            Assert.IsNotNull(deletedAppointment);
            Assert.AreEqual(6, deletedAppointment.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Appointment result = appointmentService.Delete(999);
            });
        }
    }
}
