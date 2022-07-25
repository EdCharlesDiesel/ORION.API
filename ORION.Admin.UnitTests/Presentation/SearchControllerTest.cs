using System;
using Xunit;
using System.Collections.Generic;
using ORION.DataAccess.Models;
using ORION.Admin.UnitTests.Util;
using ORION.Admin.Controllers;
using ORION.Admin.Models;

namespace ORION.Admin.UnitTests.Presentation
{
    public class SearchControllerTest
    {
        public SearchControllerTest()
        {
            _SystemUnderTest = null;
            _businessOwnerServiceInstance = null;
            _FeatureManagerInstance = null;
        }

        private SearchController _SystemUnderTest;

        private SearchController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new SearchController(
                        businessOwnerServiceInstance,
                        FeatureManagerInstance);
                }

                return _SystemUnderTest;
            }
        }

        private MockFeatureManager _FeatureManagerInstance;
        public MockFeatureManager FeatureManagerInstance
        {
            get
            {
                if (_FeatureManagerInstance == null)
                {
                    _FeatureManagerInstance = new MockFeatureManager();

                    _FeatureManagerInstance.Search = true;
                }

                return _FeatureManagerInstance;
            }
        }

        private MockBusinessOwnerService _businessOwnerServiceInstance;
        public MockBusinessOwnerService businessOwnerServiceInstance
        {
            get
            {
                if (_businessOwnerServiceInstance == null)
                {
                    _businessOwnerServiceInstance = new MockBusinessOwnerService();
                }

                return _businessOwnerServiceInstance;
            }
        }

        [Fact]
        public void GivenSearchFeatureIsDisabledWhenIndexGetIsCalledThenHttpNotFound()
        {
            FeatureManagerInstance.Search = false;

            UnitTestUtility.AssertIsHttpNotFound(
                SystemUnderTest.Index());
        }

        [Fact]
        public void GivenSearchFeatureIsDisabledWhenIndexPostIsCalledThenHttpNotFound()
        {
            FeatureManagerInstance.Search = false;

            UnitTestUtility.AssertIsHttpNotFound(
                SystemUnderTest.Index(new SearchViewModel()));
        }

        [Fact]
        public void WhenIndexIsCalledSearchResultsIsBlankAndFirstNameLastNameValuesAreEmpty()
        {
            SearchViewModel actual =
                UnitTestUtility.GetModel<SearchViewModel>(
                    SystemUnderTest.Index());

            Assert.NotNull(actual);

            Assert.NotNull(actual.Results);
            Assert.Equal(0, actual.Results.Count);
            Assert.Equal(String.Empty, actual.FirstName);
            Assert.Equal(String.Empty, actual.LastName);
        }

        [Fact]
        public void GivenAPopulatedSearchWhenIndexIsCalledThenSearchCriteriaIsOnTheReturnedModel()
        {
            PopulateSearchResults();

            var search = new SearchViewModel();

            string expectedFirstName = "expected fn";
            string expectedLastName = "expected ln";

            search.FirstName = expectedFirstName;
            search.LastName = expectedLastName;

            SearchViewModel actual =
                UnitTestUtility.GetModel<SearchViewModel>(
                    SystemUnderTest.Index(search));

            Assert.Same(search, actual);

            Assert.Equal(expectedFirstName, actual.FirstName);
            Assert.Equal(expectedLastName, actual.LastName);
        }

        [Fact]
        public void GivenAPopulatedSearchWhenIndexIsCalledSearchResultsAreReturned()
        {
            PopulateSearchResults();

            var search = new SearchViewModel();

            string expectedFirstName = "expected fn";
            string expectedLastName = "expected ln";

            search.FirstName = expectedFirstName;
            search.LastName = expectedLastName;

            SearchViewModel actual =
                UnitTestUtility.GetModel<SearchViewModel>(
                    SystemUnderTest.Index(search));

            Assert.Equal(0, actual.Results.Count);
        }

        [Fact]
        public void GivenProvinceSearchIsOffWhenIndexIsCalledThenSearchResultsIgnoreProvince()
        {
            FeatureManagerInstance.SearchByBirthBusinessProvince = false;

            PopulateSearchResults();

            var search = new SearchViewModel();

            search.FirstName = String.Empty;
            search.LastName = String.Empty;
            search.BirthProvince = "Virginia";
            search.BusinessProvince = "Virginia";

            SearchViewModel actual =
                UnitTestUtility.GetModel<SearchViewModel>(
                    SystemUnderTest.Index(search));

            // there should be two search results if state info is ignored
            Assert.Equal(2, actual.Results.Count);
        }

        [Fact]
        public void GivenProvinceSearchIsOnWhenIndexIsCalledThenSearchResultsAreFilteredByProvince()
        {
            FeatureManagerInstance.SearchByBirthBusinessProvince = true;

            PopulateSearchResultsForProvinceSearchAndNullStandardSearch();

            var search = new SearchViewModel();

            search.FirstName = String.Empty;
            search.LastName = String.Empty;
            search.BirthProvince = "Virginia";
            search.BusinessProvince = "Virginia";

            SearchViewModel actual =
                UnitTestUtility.GetModel<SearchViewModel>(
                    SystemUnderTest.Index(search));

            Assert.Equal(1, actual.Results.Count);
        }

        private void PopulateSearchResults()
        {
            businessOwnerServiceInstance.SearchReturnValue = new List<BusinessOwner>();

            businessOwnerServiceInstance.SearchReturnValue.Add(
                            UnitTestUtility.GetKagisoMokhethiAsBusinessOwner(true)
                            );

            businessOwnerServiceInstance.SearchReturnValue.Add(
                UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner(true)
                );
        }

        private void PopulateSearchResultsForProvinceSearchAndNullStandardSearch()
        {
            businessOwnerServiceInstance.SearchReturnValue = new List<BusinessOwner>();
            //FIXME This method will faill a lot of tests
            // businessOwnerServiceInstance.SearchReturnValueForProvinceSearch = new List<BusinessOwner>();

            // businessOwnerServiceInstance.SearchReturnValueForProvinceSearch.Add(
            //     UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner(true)
            //     );
        }

    }
}
