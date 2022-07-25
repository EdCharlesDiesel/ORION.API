using System;
using ORION.DataAccess.Models;
using ORION.Domain.Constants;
using Xunit;

namespace ORION.Admin.UnitTests.Models
{
    public class PersonTest
    {
        public PersonTest()
        {
            _SystemUnderTest = null;
        }

        private Person _SystemUnderTest;
        public Person SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new Person();
                }

                return _SystemUnderTest;
            }
        }

        [Fact]
        public void WhenCreatedThenFirstNameIsEmptyString()
        {
            Assert.Equal(String.Empty, SystemUnderTest.FirstName);
        }

        [Fact]
        public void WhenCreatedThenLastNameIsEmptyString()
        {
            Assert.Equal(String.Empty, SystemUnderTest.LastName);
        }

        [Fact]
        public void WhenCreatedThenBusinesesCollectionNotNull()
        {
            Assert.NotNull(SystemUnderTest.Businesses);
        }

        [Fact]
        public void WhenCreatedThenRelationshipsCollectionNotNull()
        {
            Assert.NotNull(SystemUnderTest.Relationships);
        }

        [Fact]
        public void WhenAddRelationshipIsCalledThenRelationshipIsAddedToCollection()
        {
            var toPerson = new Person();

            var expectedRelationshipType = "Vice BusinessOwner";

            SystemUnderTest.AddRelationship(expectedRelationshipType, toPerson);

            Assert.Equal(1, SystemUnderTest.Relationships.Count);

            var actual = SystemUnderTest.Relationships[0];

            Assert.Equal(expectedRelationshipType, actual.RelationshipType);
            Assert.Same(toPerson, actual.ToPerson);
            Assert.Same(SystemUnderTest, actual.FromPerson);
        }

        [Fact]
        public void WhenAddBusinessIsCalledThenBusinessIsAddedToCollection_StringBasedBusiness()
        {
            var expectedBusinessType = "Role";
            var expectedBusinessValue = "US Senator";

            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessValue);

            Assert.Equal(1, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Same(SystemUnderTest, actual.Person);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void WhenAddBusinessIsCalledWithNewValueThenBusinessIsUpdated_NonDuplicatingStringBasedBusiness()
        {
            var expectedBusinessType = "Role";
            var originalBusinessValue = "Janitor";
            var expectedBusinessValue = "US Senator";

            SystemUnderTest.AddBusiness(expectedBusinessType, originalBusinessValue);
            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessValue);

            Assert.Equal(1, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Same(SystemUnderTest, actual.Person);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void WhenAddBusinessIsCalledThenBusinessIsAddedToCollection_DateBasedBusiness()
        {
            var expectedBusinessType = BusinessOwnerConstants.BirthDate;
            var expectedBusinessValue = expectedBusinessType;
            var expectedBusinessDate = new DateTime(1928, 4, 3);

            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessDate);

            Assert.Equal(1, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Equal<DateTime>(expectedBusinessDate, actual.StartDate);
            Assert.Equal<DateTime>(expectedBusinessDate, actual.EndDate);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void WhenAddBusinessIsCalledTwiceThenBusinessIsUpdated_NonDuplicatingDateBasedBusiness()
        {
            var expectedBusinessType = BusinessOwnerConstants.BirthDate;
            var expectedBusinessValue = expectedBusinessType;
            var expectedBusinessDate = new DateTime(1928, 4, 3);

            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessDate.AddYears(-5));
            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessDate);

            Assert.Equal(1, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Equal<DateTime>(expectedBusinessDate, actual.StartDate);
            Assert.Equal<DateTime>(expectedBusinessDate, actual.EndDate);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void WhenAddBusinessIsCalledThenBusinessIsAddedToCollection_DateRangeBusiness()
        {
            var expectedBusinessType = BusinessOwnerConstants.BusinessOwner;
            var expectedBusinessValue = expectedBusinessType;
            var expectedBusinessStartDate = new DateTime(1928, 4, 3);
            var expectedBusinessEndDate = new DateTime(1929, 4, 3);

            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessStartDate, expectedBusinessEndDate);

            Assert.Equal(1, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Equal<DateTime>(expectedBusinessStartDate, actual.StartDate);
            Assert.Equal<DateTime>(expectedBusinessEndDate, actual.EndDate);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void WhenAddBusinessIsCalledThenBusinessIsAddedToCollection_DateRangeBusinessThatAllowsDuplicates()
        {
            var expectedBusinessType = BusinessOwnerConstants.BusinessOwner;
            var expectedBusinessValue = expectedBusinessType;
            var expectedBusinessStartDate = new DateTime(1928, 4, 3);
            var expectedBusinessEndDate = new DateTime(1929, 4, 3);

            SystemUnderTest.AddBusiness(expectedBusinessType, expectedBusinessStartDate, expectedBusinessEndDate);
            SystemUnderTest.AddBusiness(expectedBusinessType,
                expectedBusinessStartDate.AddYears(10),
                expectedBusinessEndDate.AddYears(10));

            Assert.Equal(2, SystemUnderTest.Businesses.Count);
        }

        [Fact]
        public void WhenAddBusinessIsCalledWithNonZeroIdThenBusinessIsModified_DateRangeBusinessThatAllowsDuplicates()
        {
            var expectedBusinessType = BusinessOwnerConstants.BusinessOwner;
            var expectedBusinessValue = expectedBusinessType;
            var expectedBusinessStartDate = new DateTime(1928, 4, 3);
            var expectedBusinessEndDate = new DateTime(1929, 4, 3);

            SystemUnderTest.AddBusiness(21,
                expectedBusinessType,
                expectedBusinessStartDate.AddDays(-10),
                expectedBusinessEndDate.AddDays(-10));

            SystemUnderTest.AddBusiness(27, expectedBusinessType,
                expectedBusinessStartDate.AddYears(10),
                expectedBusinessEndDate.AddYears(10));

            // modify an existing saved fact
            SystemUnderTest.AddBusiness(21,
                expectedBusinessType,
                expectedBusinessStartDate,
                expectedBusinessEndDate);

            Assert.Equal(2, SystemUnderTest.Businesses.Count);

            var actual = SystemUnderTest.Businesses[0];

            Assert.Equal(21, actual.Id);
            Assert.Equal(expectedBusinessType, actual.BusinessType);
            Assert.Equal(expectedBusinessValue, actual.BusinessValue);
            Assert.Equal<DateTime>(expectedBusinessStartDate, actual.StartDate);
            Assert.Equal<DateTime>(expectedBusinessEndDate, actual.EndDate);
            Assert.Same(SystemUnderTest, actual.Person);
        }

        [Fact]
        public void RemoveBusinessById()
        {
            var removeThisId = 123;
            var fact0 = new PersonBusiness() { Id = removeThisId };
            var fact1 = new PersonBusiness() { Id = 456 };

            SystemUnderTest.Businesses.Add(fact0);
            SystemUnderTest.Businesses.Add(fact1);

            SystemUnderTest.RemoveBusiness(removeThisId);

            Assert.False(SystemUnderTest.Businesses.Contains(fact0));
        }
    }
}
