using ORION.Admin.Models;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class BusinessOwnerToSearchResultRowAdapterTest
    {
        public BusinessOwnerToSearchResultRowAdapterTest()
        {
            _SystemUnderTest = null;
        }

        private BusinessOwnerToSearchResultRowAdapter _SystemUnderTest;

        private BusinessOwnerToSearchResultRowAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new BusinessOwnerToSearchResultRowAdapter();
                }

                return _SystemUnderTest;
            }
        }

        [Fact]
        public void AdaptBusinessOwnerToSearchResultRow()
        {
            var actual = new SearchResultRow();

            var fromValue = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true);

            SystemUnderTest.Adapt(fromValue, actual);

            AssertAreEqual(fromValue, actual);
        }

        private void AssertAreEqual(BusinessOwner expected, SearchResultRow actual)
        {
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal<int>(expected.Id, actual.Id);
        }
            }
}
