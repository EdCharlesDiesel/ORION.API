using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using ORION.DataAccess.Services;
using Xunit;

namespace ORION.Admin.UnitTests.Services
{
    public class PersonToBusinessOwnerAdapterTest
    {
        public PersonToBusinessOwnerAdapterTest()
        {
             _SystemUnderTest = null;
        }
        
        private PersonToBusinessOwnerAdapter _SystemUnderTest;
        public PersonToBusinessOwnerAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new PersonToBusinessOwnerAdapter();
                }

                return _SystemUnderTest;
            }
        }

        [Fact]
        public void AdaptPersonToBusinessOwner_OneTerm()
        {
            var fromValue = UnitTestUtility.GetKhotsoMokhethiAsPerson();
            var toValue = new BusinessOwner();

            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void AdaptPersonToBusinessOwner_TwoTerms()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsPerson();
            var toValue = new BusinessOwner();

            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void GivenASavedPersonWhenAdaptPersonToBusinessOwner_TwoTerms()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsPerson(true);
            var toValue = new BusinessOwner();

            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void AdaptBusinessOwnerToPerson_OneTerm()
        {
            var fromValue = UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner();
            var toValue = new Person();

            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void AdaptBusinessOwnerToPerson_TwoTerms()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();
            var toValue = new Person();

            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void AdaptBusinessOwnerToPerson_GivenAnEmptyPersonWhenBusinessOwnerHasDeletedTermsThenDeletedTermsAreSkipped()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);
            var fromValueTermThatsMarkedForDelete = fromValue.Terms[0];
            fromValueTermThatsMarkedForDelete.IsDeleted = true;

            var toValue = new Person();

            SystemUnderTest.Adapt(fromValue, toValue);

            fromValue.Terms.Remove(fromValueTermThatsMarkedForDelete);
            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void AdaptBusinessOwnerToPerson_GivenANonEmptyPersonWhenBusinessOwnerHasDeletedTermsThenDeletedTermsAreSkipped()
        {
            // arrange
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);
            var toValue = new Person();
            SystemUnderTest.Adapt(fromValue, toValue);
            var fromValueTermThatsMarkedForDelete = fromValue.Terms[0];
            Assert.NotEqual<int>(0, 
                fromValueTermThatsMarkedForDelete.Id);
            fromValueTermThatsMarkedForDelete.IsDeleted = true;

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            fromValue.Terms.Remove(fromValueTermThatsMarkedForDelete);
            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void GivenAnUnsavedBusinessOwnerWhenAdaptIsCalledTwiceThenNoDuplicatesAreCreated()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();
            var toValue = new Person();

            SystemUnderTest.Adapt(fromValue, toValue);
            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [Fact]
        public void GivenASavedBusinessOwnerWhenAdaptIsCalledTwiceThenNoDuplicatesAreCreated()
        {
            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);
            var toValue = new Person();

            SystemUnderTest.Adapt(fromValue, toValue);
            SystemUnderTest.Adapt(fromValue, toValue);

            UnitTestUtility.AssertAreEqual(fromValue, toValue);
        }
    }
}
