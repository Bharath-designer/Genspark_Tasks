using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseModelLibrary;

namespace ClinicTestCaseTestFiles
{
    public class DoctorTest
    {
        IDoctorService doctorService;

        [SetUp]
        public void Setup()
        {
            IRepository<int, Doctor> repo = new DoctorRepository();
            doctorService = new DoctorBL(repo);
        }

        [Test]
        public void AddSuccessTest()
        {

            Doctor doc = new Doctor(1, "Ram", "General Anesthesia");

            Doctor result = doctorService.Add(doc);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {

            Doctor doc = new Doctor(2, "Ram", "General Anesthesia");
            doctorService.Add(doc);
            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Doctor result = doctorService.Add(doc);
            });
        }

        [Test]
        public void AddFailTest2()
        {

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Doctor result = doctorService.Add(null);
            });
        }

        [Test]
        public void GetByIdSuccessTest()
        {
            Doctor doc = new Doctor(3, "John", "Pediatrician");
            doctorService.Add(doc);

            Doctor result = doctorService.GetById(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void GetByIdFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Doctor result = doctorService.GetById(999); 
            });
        }
        [Test]
        public void GetAllSuccessTest()
        {

            List<Doctor> allDoctors = doctorService.GetAll();

            Assert.IsNotNull(allDoctors);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            Doctor doc = new Doctor(4, "Jane", "Cardiologist");
            doctorService.Add(doc);

            doc.Name = "Jane Smith";
            doc.Specialization = "Neurologist";
            Doctor updatedDoctor = doctorService.Update(doc);

            Assert.IsNotNull(updatedDoctor);
            Assert.AreEqual("Jane Smith", updatedDoctor.Name);
            Assert.AreEqual("Neurologist", updatedDoctor.Specialization);
        }

        [Test]
        public void UpdateFailTest()
        {
            Doctor doc = new Doctor(5, "Alex", "Dermatologist");

            Assert.Throws<IdNotFoundException>(() =>
            {
                Doctor result = doctorService.Update(doc);
            });
        }

        [Test]
        public void UpdateFailTest2()
        {

            Assert.Throws<IdNotFoundException>(() =>
            {
                Doctor result = doctorService.Update(null);
            });
        }

        [Test]
        public void DeleteSuccessTest()
        {
            Doctor doc = new Doctor(6, "David", "Orthopedic Surgeon");
            doctorService.Add(doc);

            Doctor deletedDoctor = doctorService.Delete(6);

            Assert.IsNotNull(deletedDoctor);
            Assert.AreEqual(6, deletedDoctor.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Doctor result = doctorService.Delete(999); 
            });
        }

    }
}
