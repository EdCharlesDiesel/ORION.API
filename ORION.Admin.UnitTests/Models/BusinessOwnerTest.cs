using System;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Models
{
    public class BusinessOwnerTest
    {
        public BusinessOwnerTest()
        {
            _SystemUnderTest = null;
        }

        private BusinessOwner? _SystemUnderTest;

        private BusinessOwner SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new BusinessOwner();
                }

                return _SystemUnderTest;
            }
        }

        // TODO Use count to assert collection is not null.
        [Fact]
        public void TermsCollectionIsNotNull()
        {
          //  Assert.NotNull(SystemUnderTest.Terms);
        }

        [Fact]
        public void FieldsAreInitialized()
        {
            Assert.Equal(String.Empty, SystemUnderTest.BirthCity);
            Assert.Equal(String.Empty, SystemUnderTest.BirthProvince);
            Assert.Equal(String.Empty, SystemUnderTest.BusinessCity);
            Assert.Equal(String.Empty, SystemUnderTest.BusinessProvince);
            Assert.Equal(String.Empty, SystemUnderTest.FirstName);
            Assert.Equal(String.Empty, SystemUnderTest.LastName);
            Assert.Equal(0, SystemUnderTest.DaysInOffice);
        }
    }
}
