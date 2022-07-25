using System;
using Xunit;
using ORION.Domain.Utility;
using ORION.DataAccess.Models;
using ORION.Admin.UnitTests.Util;
using ORION.Domain.Constants;

namespace ORION.Admin.UnitTests.Models
{
    public class BusinessOwnerValidatorTest
    {
        private DefaultValidatorStrategy<BusinessOwner> _SystemUnderTest;
        public DefaultValidatorStrategy<BusinessOwner> SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new DefaultValidatorStrategy<BusinessOwner>();
                }

                return _SystemUnderTest;
            }
        }

        [Fact]
        public void ValidateBusinessOwner_DefaultConstructor_ReturnsFalse()
        {
            var businessOwner = new BusinessOwner();

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.False(result);
        }

        [Fact]
        public void ValidateBusinessOwner_PopulatedBusinessOwner_ReturnsTrue()
        {
            var businessOwner = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.True(result);
        }

        [Fact]
        public void ValidateBusinessOwner_NonDeadBusinessOwner_ReturnsTrue()
        {
            var businessOwner = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

            businessOwner.BusinessDate = default(DateTime);

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.True(result, "Should be valid.");
        }

        [Fact]
        public void ValidateBusinessOwner_BirthDateAfterBusinessDate_ReturnsFalse()
        {
            var businessOwner = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

            businessOwner.BirthDate = businessOwner.BusinessDate.AddYears(1);

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.False(result);
        }


        [Fact]
        public void ValidateBusinessOwner_BusinessDateBeforeBirthDate_ReturnsFalse()
        {
            var businessOwner = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

            businessOwner.BusinessDate = businessOwner.BirthDate.AddYears(-1);

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.False(result, "Should be invalid.");
        }

        [Fact]
        public void ValidateBusinessOwner_BusinessOwnerWithZeroTerms_ReturnsFalse()
        {
            //var businessOwner = UnitTestUtility.GetGroverClevelandAsBusinessOwner();
            var businessOwner = UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner();

            businessOwner.Terms.Clear();

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.False(result, "Should not be valid.");
        }

        [Fact]
        public void ValidateBusinessOwner_BusinessOwnerWithThreeTerms_ReturnsFalse()
        {
            var businessOwner = UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner();

            businessOwner.AddTerm(BusinessOwnerConstants.BusinessOwner,
                DateTime.Now, DateTime.Now.AddYears(4), 46);

            var result = SystemUnderTest.IsValid(businessOwner);

            Assert.False(result, "Should not be valid.");
        }

    }
}