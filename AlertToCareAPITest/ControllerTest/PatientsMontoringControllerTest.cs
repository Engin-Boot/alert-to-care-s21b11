//using AlertToCareAPITest.ControllerInterfaces;
using AlertToCareAPI.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

using AlertToCareAPITest.RepoTest;
using AlertToCareAPI.Repo;

namespace AlertToCareAPITest.ControllerTest
{
   public class PatientsMontoringControllerTest : InMemoryContext
    {
         
        private readonly PatientsMonitoringController _patientsMonitoringController;

        public PatientsMontoringControllerTest()
        {
            IMonitoringRepo _monitoringRepo = new MonitorinRepository(Context);
            _patientsMonitoringController = new PatientsMonitoringController(_monitoringRepo);
        }

        [Theory]
        [InlineData("ICU001")]
        public void TestGetAllAlertsWhenIcuidIsValid(string icuId)
        {
            var alertList = _patientsMonitoringController.GetAlerts(icuId);
            Assert.IsType<OkObjectResult>(alertList);
        }

        [Theory]
        [InlineData("ABC456")]
        public void TestGetAllAlertsWhenIcuidIsInvalid(string icuId)
        {
            var alertList = _patientsMonitoringController.GetAlerts(icuId);
            Assert.IsType<OkObjectResult>(alertList);
        }

        [Fact]
        public void TestAlertStatusChange()
        {
            string alertId = "AL002";
            var isStatusChanged = _patientsMonitoringController.ChangeStatusOfAlert(alertId);
            Assert.IsType<OkObjectResult>(isStatusChanged);
        }

        [Fact]
        public void TestDeleteAlertForPatientId()
        {
            string patID = "P02";
            var isPatientDeleted = _patientsMonitoringController.RemoveAlertOfDischargedPat(patID);
            Assert.IsType<OkObjectResult>(isPatientDeleted);
        }

        [Fact]
        public void TestGetUnOccupiedBedsWhenValidIcuid()
        {
            string icuId = "ICU001";
            var bedsList = _patientsMonitoringController.GetUnoccupiedBeds(icuId);
            Assert.IsType<OkObjectResult>(bedsList);
        }

        [Fact]
        public void TestGetUnOccupiedBedsWhenInvalidIcuId()
        {
            string icuId = "ICU002";
            var bedsList = _patientsMonitoringController.GetUnoccupiedBeds(icuId);
            Assert.IsType<BadRequestObjectResult>(bedsList);
        }
    }
}
