using AlertToCareAPI.Controllers;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
    public class IcuConfigControllerTest : InMemoryContext
    {

        private readonly IIcuConfigurationRepository _repository;
        private readonly IcuConfigController _icuController;

        public IcuConfigControllerTest()
        {

            _repository = new IcuConfigrationRepository(Context);
            _icuController = new IcuConfigController(_repository);
        }

        [Fact]
        public void TestGetAllIcUs()
        {
            var icus = _icuController.GetAllIcus();
            Assert.NotEmpty(icus);

        }
        [Fact]
        public void TestGetSpecificIcu()
        {
            var icus = _icuController.GetSpecificIcu("ICU001");
            Assert.IsType<OkObjectResult>(icus);

        }
        [Fact]
        public void TestGetSpecificIcuWhenIcuNotPresentWithId()
        {
            var icus = _icuController.GetSpecificIcu("ICU008");
            Assert.IsType<NotFoundObjectResult>(icus);
        }

        [Fact]
        public void TestUpdateIcu()
        {
            var newIcu = new Icu
            {
                Id = "ICU001",
                BedCount = 15,
                LayoutId = "L001"
            };
            var icuInfo = _icuController.UpdateIcu("ICU001", newIcu);
            Assert.IsType<OkResult>(icuInfo);
        }

        [Fact]
        public void TestUpdateIcuWithMismatchInIds()
        {
            var newIcu = new Icu
            {
                Id = "ICU002",//id mismatch
                BedCount = 15,
                LayoutId = "L001"
            };
            var icuInfo = _icuController.UpdateIcu("ICU001", newIcu);//id mismatch
            Assert.IsType<BadRequestObjectResult>(icuInfo);
        }
        [Fact]
        public void TestUpdateIcuWithIcuIdNotRegistered()
        {
            var newIcu = new Icu
            {
                Id = "ICU042",
                BedCount = 15,
                LayoutId = "L001"
            };
            var icuInfo = _icuController.UpdateIcu("ICU042", newIcu);
            Assert.IsType<NotFoundResult>(icuInfo);
        }
        [Fact]
        public void TestDeleteIcuWithValidId()
        {
            var icu = _icuController.DeleteIcu("ICU001");
            //Assert.NotNull(_Icu);
            Assert.IsType<OkResult>(icu);
        }
        [Fact]
        public void TestDeleteIcuWithInValidId()
        {
            var icu = _icuController.DeleteIcu("ICU0010");
            //Assert.NotNull(_Icu);
            Assert.IsType<NotFoundResult>(icu);
        }
        [Fact]
        public void TestAddIcuWithValidData()
        {
            var newIcu = new Icu
            {
                Id = "ICU003",
                BedCount = 10,
                LayoutId = "L001"
            };
            var icu = _icuController.AddIcu(newIcu);
            Assert.NotNull(icu);
            Assert.IsType<OkObjectResult>(icu);
        }
        [Fact]
        public void TestAddWithInValidIcuData()
        {
            var newIcu = new Icu
            {
                BedCount = 10

            };
            var icu = _icuController.AddIcu(newIcu);

            Assert.IsType<BadRequestObjectResult>(icu);
        }
        [Fact]
        public void TestAddWithLayoutIdNotRegistered()
        {
            var newIcu = new Icu
            {
                Id = "ICU004",
                BedCount = 10,
                LayoutId = "L004"

            };
            var icu = _icuController.AddIcu(newIcu);
            Assert.IsType<BadRequestObjectResult>(icu);
            Assert.IsNotType<OkObjectResult>(icu);
        }
        [Fact]
        public void TestAddWithAddingIcuWithSamePrimaryKey()
        {
            var newIcu = new Icu
            {
                Id = "ICU001",
                BedCount = 12,
                LayoutId = "L001"

            };
            var icu = _icuController.AddIcu(newIcu);
            Assert.IsType<BadRequestObjectResult>(icu);
            Assert.IsNotType<OkObjectResult>(icu);
        }
        [Fact]
        public void TestGetAllLayouts()
        {
            var layouts = _icuController.GetAllLayouts();
            Assert.NotEmpty(layouts);
        }
        [Fact]
        public void TestAddBedsWithValidData()
        {
            var addbeds = _icuController.AddBeds("ICU001", 12);
            Assert.IsType<OkResult>(addbeds);
        }
        [Fact]
        public void TestAddBedsWithInValidData()
        {
            var addbeds = _icuController.AddBeds("ICU001", 10);
            Assert.IsType<BadRequestObjectResult>(addbeds);
        }

    }
}
