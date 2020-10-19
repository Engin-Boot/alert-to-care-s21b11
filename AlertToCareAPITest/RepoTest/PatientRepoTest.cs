using System;
using System.Linq;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPI.Database;
using Xunit;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;

namespace AlertToCareTest.RepoTest
{
    public class PatientRepoTest : AlertToCareAPITest.RepoTest.InMemoryContext
    {
        
        //PatientRepository _PatientData = new PatientRepository(Context);

        [Fact]
        public void TestAddPatientSuccessful()
        {
            var dummyPatient = new Patient
            {
                Id = "P03",
                PatientName = "Nortan",
                Age = 24,
                IcuId = "ICU003",
                BedId = "B003",
                ContantNumber = "2234"
            };
            var patientData = new PatientRepository(Context);
            patientData.AddNewPatient(dummyPatient);
            var patientDataInDb = Context.PatientsInfo.FirstOrDefault
                (p => p.PatientName == "Nortan");
            Assert.NotNull(patientDataInDb);
        }

        [Fact]
        public void CheckWeatherWeGetListOfAllPatients()
        {
            var PatientData = new PatientRepository(Context);
            var _Patients = PatientData.GetDetailsOfAllPatients();
            Assert.NotNull(_Patients);
        }

        [Theory]
        [InlineData("P01")]
        [InlineData("P02")]
        public void CheckICUIdWhenpatientIdIsGiven(string PatientId)
        {
            var _PatientInfo = new PatientRepository(Context);
            Patient _Patient = new Patient();
            _Patient = _PatientInfo.GetPatientById(PatientId);
            //string _ExpectedIcuId = _Patient.IcuId;
            if (PatientId == "P01")
                Assert.Null(_Patient);
            else
                Assert.Equal("ICU002", _Patient.IcuId);
        }

        //[Fact]
        //public void CheckForDischargingOfPatient()
        //{
        //    var _PatientData = new PatientRepository(Context);
        //    var _Patient = _PatientData.GetPatientById("P04");
        //    Assert.NotNull(_Patient);
        //    _PatientData.RemovePatient(_Patient);
            
        //    Assert.Null(_PatientData.GetPatientById("P04"));

        //}

        [Fact]
        public void CheckSaveChanges()
        {
            var _Patient = new PatientRepository(Context);
            Assert.True(_Patient.SaveChanges());
        }
    }
}
