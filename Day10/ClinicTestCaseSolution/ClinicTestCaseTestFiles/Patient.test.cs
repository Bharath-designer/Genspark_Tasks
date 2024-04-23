using ClinicTestCaseBLLibrary;
using ClinicTestCaseDALLibrary;
using ClinicTestCaseModelLibrary;
using NUnit.Framework;

namespace ClinicTestCaseTestFiles
{
    public class PatientTest
    {
        IPatientService patientService;

        [SetUp]
        public void Setup()
        {
            IRepository<int, Patient> repo = new PatientRepository();
            patientService = new PatientBL(repo);
        }

        [Test]
        public void AddSuccessTest()
        {
            Patient patient = new Patient(1, "Ram", 35);

            Patient result = patientService.Add(patient);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
            Patient patient = new Patient(2, "Ram", 28);
            patientService.Add(patient);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Patient result = patientService.Add(patient);
            });
        }

        [Test]
        public void AddFailTest2()
        {
            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                Patient result = patientService.Add(null);
            });
        }

        [Test]
        public void GetByIdSuccessTest()
        {
            Patient patient = new Patient(3, "Ram", 45);
            patientService.Add(patient);

            Patient result = patientService.GetById(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void GetByIdFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Patient result = patientService.GetById(999);
            });
        }

        [Test]
        public void GetAllSuccessTest()
        {
            var allPatients = patientService.GetAll();

            Assert.IsNotNull(allPatients);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            Patient patient = new Patient(4, "Ram", 50);
            patientService.Add(patient);

            patient.Name = "Ram";
            patient.Age = 55;
            Patient updatedPatient = patientService.Update(patient);

            Assert.IsNotNull(updatedPatient);
            Assert.AreEqual("Ram", updatedPatient.Name);
            Assert.AreEqual(55, updatedPatient.Age);
        }

        [Test]
        public void UpdateFailTest()
        {
            Patient patient = new Patient(5, "Ram", 30);

            Assert.Throws<IdNotFoundException>(() =>
            {
                Patient result = patientService.Update(patient);
            });
        }

        [Test]
        public void UpdateFailTest2()
        {

            Assert.Throws<IdNotFoundException>(() =>
            {
                Patient result = patientService.Update(null);
            });
        }

        [Test]
        public void DeleteSuccessTest()
        {
            Patient patient = new Patient(6, "Ram", 40);
            patientService.Add(patient);

            Patient deletedPatient = patientService.Delete(6);

            Assert.IsNotNull(deletedPatient);
            Assert.AreEqual(6, deletedPatient.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                Patient result = patientService.Delete(999);
            });
        }
    }
}
