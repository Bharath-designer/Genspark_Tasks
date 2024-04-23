using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseModelLibrary;

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
            Appointment appointment = new Appointment(1, DateTime.Now, 1, 1);

            Appointment result = appointmentService.Add(appointment);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
            Appointment appointment = new Appointment(2, DateTime.Now, 2, 2);
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
            Appointment appointment = new Appointment(3, DateTime.Now, 3, 3);
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
            Appointment appointment = new Appointment(4, DateTime.Now, 4, 4);
            appointmentService.Add(appointment);

            appointment.Date = DateTime.Now.AddDays(1);
            Appointment updatedAppointment = appointmentService.Update(appointment);

            Assert.IsNotNull(updatedAppointment);
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, updatedAppointment.Date.Date);
        }

        [Test]
        public void UpdateFailTest()
        {
            Appointment appointment = new Appointment(5, DateTime.Now, 5, 5);

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
            Appointment appointment = new Appointment(6, DateTime.Now, 6, 6);
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
