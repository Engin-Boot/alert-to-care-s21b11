using AlertToCareAPI.Controllers;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
    public class IcuOccupancyControllerTest : InMemoryContext
    {

        private readonly IPatientRepo _repository;
        private readonly IcuOccupancyController _occupancyController;
        public IcuOccupancyControllerTest()
        {

            _repository = new PatientRepository(Context);
            _occupancyController = new IcuOccupancyController(_repository);
        }
        [Fact]
        public void TestGetAllPatients()
        {
            var patients = _occupancyController.GetAllPatients();
            Assert.NotEmpty(patients);
        }

        [Fact]
        public void TestGetPatientWithValidId()
        {
            var patients = _occupancyController.GetPatientById("P01");
            Assert.IsType<OkObjectResult>(patients);
        }
        [Fact]
        public void TestGetPatientWithInValidId()
        {
            var patients = _occupancyController.GetPatientById("P010");
            Assert.IsType<BadRequestObjectResult>(patients);
        }
        [Fact]
        public void TestGetAllAvailableBeds()
        {
            var availableBeds = _occupancyController.GetAvailableBeds();
            Assert.IsType<OkObjectResult>(availableBeds);

        }
        [Fact]
        public void TestGetAllAvailableBedsForSpecificIcu()
        {
            var availableBeds = _occupancyController.GetAvailableBedsForIcu("ICU001");
            Assert.IsType<OkObjectResult>(availableBeds);

        }
        [Fact]
        public void TestWhenThereAreNoAvailableBeds()
        {
            var availableBeds = _occupancyController.GetAvailableBedsForIcu("ICU002");
            Assert.IsType<BadRequestObjectResult>(availableBeds);


        }
        [Fact]
        public void TestAddNewPatientWithValidDetails()
        {
            var patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B003",
                IcuId = "ICU001"
            };
            var newPatient = _occupancyController.AddNewPatient(patient);

            Assert.IsType<OkResult>(newPatient);
        }
        [Fact]
        public void TestAddNewPatientWithSameId()
        {
            var patient = new Patient
            {
                Id = "P01",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B003",
                IcuId = "ICU001"
            };
            var newPatient = _occupancyController.AddNewPatient(patient);

            Assert.IsType<BadRequestObjectResult>(newPatient);
        }
        [Fact]
        public void TestAddNewPatientWithInvalidBedIdandIcuIdDetails()
        {
            var patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B0034",
                IcuId = "ICU001"
            };
            var newPatient = _occupancyController.AddNewPatient(patient);

            Assert.IsType<BadRequestObjectResult>(newPatient);
        }
        [Fact]
        public void TestAddNewPatientWithBedIdOccupied()
        {
            var patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B001",
                IcuId = "ICU001"
            };
            var newPatient = _occupancyController.AddNewPatient(patient);
            Assert.IsType<BadRequestObjectResult>(newPatient);
        }
        [Fact]
        public void TestRemovePatientWithValidDetails()
        {

            var newPatient = _occupancyController.RemovePatient("P01", "ICU001");
            Assert.IsType<OkResult>(newPatient);
        }
        [Fact]
        public void TestRemovePatientWithInValidId()
        {

            var newPatient = _occupancyController.RemovePatient("P0109", "ICU001");
            Assert.IsType<NotFoundResult>(newPatient);
        }
        [Fact]
        public void TestGetPatientInfo()
        {
            var patient = _occupancyController.GetPatientInfo("B001", "ICU001");
            Assert.Equal("P01", patient.Id);

        }
    }
}
