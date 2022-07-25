
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ORION.Admin.Controllers;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using ORION.Domain.Utility;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class BusinessOwnerControllerTest
    {
        public BusinessOwnerControllerTest()
        {
              _SystemUnderTest = null;
            _BusinessOwnerServiceInstance = null;
        }

        private BusinessOwnerController _SystemUnderTest;

        private BusinessOwnerController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new BusinessOwnerController(
                        BusinessOwnerServiceInstance,
                        new DefaultValidatorStrategy<BusinessOwner>(),
                        null
                        );
                }

                return _SystemUnderTest;
            }
        }

        private MockBusinessOwnerService _BusinessOwnerServiceInstance;
        public MockBusinessOwnerService BusinessOwnerServiceInstance
        {
            get
            {
                if (_BusinessOwnerServiceInstance == null)
                {
                    _BusinessOwnerServiceInstance = new MockBusinessOwnerService();
                }

                return _BusinessOwnerServiceInstance;
            }
        }

        [Fact]
        public void WhenIndexIsCalledThenAllBusinessOwnersAreReturned()
        {
            BusinessOwnerServiceInstance.GetBusinessOwnersReturnValue.Add(
                UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true)
                );

            BusinessOwnerServiceInstance.GetBusinessOwnersReturnValue.Add(
                UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner(true)
                );

            var model = 
                UnitTestUtility.GetModel<IList<BusinessOwner>>(
                    SystemUnderTest.Index());

            Assert.NotNull(model);

            Assert.NotEqual<int>(0, model.Count);
        }

        [Fact]
        public void WhenDetailsIsCalledForValidBusinessOwnerIdThenBusinessOwnerIsReturned()
        {
            var expected = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);

            BusinessOwnerServiceInstance.GetBusinessOwnerByIdReturnValue =
                expected;

            var model =
                UnitTestUtility.GetModel<BusinessOwner>(
                    SystemUnderTest.Details(1234));

            Assert.NotNull(model);

            Assert.Same(expected, model);
    
        }

        [Fact(Skip=("WhenDetailsIsCalledForUnknownBusinessOwnerIdThenHttpNotFoundReturned"))]
        public void WhenDetailsIsCalledForUnknownBusinessOwnerIdThenHttpNotFoundReturned()
        {
            BusinessOwnerServiceInstance.GetBusinessOwnerByIdReturnValue = null;

            UnitTestUtility.AssertIsHttpNotFound(
                SystemUnderTest.Details(1234));
        }

        [Fact]
        public void WhenEditIsCalledForLoadForValidBusinessOwnerIdThenBusinessOwnerIsReturned()
        {
            var expected = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);

            BusinessOwnerServiceInstance.GetBusinessOwnerByIdReturnValue =
                expected;

            var model =
                UnitTestUtility.GetModel<BusinessOwner>(
                    SystemUnderTest.Edit(1234));

            Assert.NotNull(model);

            Assert.Same(expected, model);
        }

        [Fact]
        public void WhenEditIsCalledForLoadForCreateNewBusinessOwnerThenThereIsAnEmptyBusinessOwnerRow()
        {
            var model =
                UnitTestUtility.GetModel<BusinessOwner>(
                    SystemUnderTest.Edit(0));

            Assert.NotNull(model);

            Assert.Equal<int>(1, model.Terms.Count);

            Assert.Equal("BusinessOwner", model.Terms[0].Role);
        }

        [Fact]
        public void WhenEditIsCalledForSaveThenBusinessOwnerIsSaved()
        {
            var saveThis = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);

            BusinessOwnerServiceInstance.GetBusinessOwnerByIdReturnValue =
                saveThis;

            var result = SystemUnderTest.Edit(saveThis) as RedirectToActionResult;

            Assert.NotNull(result);

            Assert.NotNull(BusinessOwnerServiceInstance.SaveBusinessOwnerArgumentValue);
        }

        [Fact(Skip=("WhenEditIsCalledForSaveNewBusinessOwnerThenBusinessOwnerIsSaved"))]
        //FIXME Assert Type
        public void WhenEditIsCalledForSaveNewBusinessOwnerThenBusinessOwnerIsSaved()
        {
            // unsaved
            var saveThis = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

            BusinessOwnerServiceInstance.GetBusinessOwnerByIdReturnValue = null;

            var result = SystemUnderTest.Edit(saveThis);

            Assert.NotNull(result);
          //  Assert.IsType(result, typeof(ViewResult));

            Assert.NotNull(BusinessOwnerServiceInstance.SaveBusinessOwnerArgumentValue);
        }
    }
}
