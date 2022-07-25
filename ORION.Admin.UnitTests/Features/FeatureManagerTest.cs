using System;
using Xunit;
using ORION.DataAccess.Models;
using ORION.DataAccess.AllFeatures;

namespace ORION.Admin.UnitTests.Features
{
    public class FeatureManagerTest
    {
        private const string TestUserName = "user@test.org";

        public FeatureManagerTest()
        {
            _SystemUnderTest = null;
            _FeatureRepositoryInstance = null;
            _UsernameProviderInstance = null;
        }

        private FeatureManager _SystemUnderTest;

        private FeatureManager SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new FeatureManager(
                        FeatureRepositoryInstance, UsernameProviderInstance);
                }

                return _SystemUnderTest;
            }
        }

        private MockUsernameProvider _UsernameProviderInstance;
        public MockUsernameProvider UsernameProviderInstance
        {
            get
            {
                if (_UsernameProviderInstance == null)
                {
                    _UsernameProviderInstance = new MockUsernameProvider();
                }

                return _UsernameProviderInstance;
            }
        }
        

        private MockFeatureRepository _FeatureRepositoryInstance;
        public MockFeatureRepository FeatureRepositoryInstance
        {
            get
            {
                if (_FeatureRepositoryInstance == null)
                {
                    _FeatureRepositoryInstance = new MockFeatureRepository();
                }

                return _FeatureRepositoryInstance;
            }
        }

        [Fact]
        public void WhenUsernameIsAvailableAndFeatureIsNotEnabledForAnyoneThenPrivateBetaIsDisabledForFeature()
        {
            SetFeatureFlagData("SearchByBirthBusinessProvince", false);
            
          //  var searchByBirthBusinessProvince = SystemUnderTest.SearchByBirthBusinessProvince;

         //   Assert.False(searchByBirthBusinessProvince);
        }

        [Fact]
        public void WhenUsernameIsAvailableAndFeatureIsEnabledForEveryoneThenPrivateBetButNotForCurrentUserThenIsEnabledTrue()
        {
          //  SetFeatureFlagData("SearchByBirthBusinessProvince", true);

          //  Assert.True(SystemUnderTest.SearchByBirthBusinessProvince);
        }

        [Fact]
        public void WhenUsernameIsAvailableAndFeatureIsNotEnabledForCurrentUserThenPrivateBetaIsDisabledForFeature()
        {
            UsernameProviderInstance.ReturnThisUsername = TestUserName;

            SetFeatureFlagData("SearchByBirthBusinessProvince", false);
           // SetFeatureFlagData("SearchByBirthBusinessProvince", false, TestUserName);

            Assert.False(SystemUnderTest.SearchByBirthBusinessProvince);
        }

        [Fact]
        public void WhenUsernameIsAvailableAndFeatureIsNotEnabledForDifferentUserThenPrivateBetaIsDisabledForFeature()
        {
            UsernameProviderInstance.ReturnThisUsername = "somebody else";

            SetFeatureFlagData("SearchByBirthBusinessProvince", false);
           // SetFeatureFlagData("SearchByBirthBusinessProvince", false, TestUserName);

            Assert.False(SystemUnderTest.SearchByBirthBusinessProvince);
        }

        [Fact]
        public void WhenUsernameIsAvailableAndFeatureIsNotEnabledForNullUserThenPrivateBetaIsDisabledForFeature()
        {
            UsernameProviderInstance.ReturnThisUsername = null;

            SetFeatureFlagData("SearchByBirthBusinessProvince", false);
           // SetFeatureFlagData("SearchByBirthBusinessProvince", false, TestUserName);

            Assert.False(SystemUnderTest.SearchByBirthBusinessProvince);
        }

        [Fact]
        public void WhenUsernameIsAvailableAndUserSpecificFeatureIsEnabledForCurrentUserThenFeatureIsEnabled()
        {
            UsernameProviderInstance.ReturnThisUsername = TestUserName;
            SetFeatureFlagData("SearchByBirthBusinessProvince", false);
           // SetFeatureFlagData("SearchByBirthBusinessProvince", true, TestUserName);

            Assert.True(SystemUnderTest.SearchByBirthBusinessProvince);
        }

        private void SetFeatureFlagData(string featureName, bool isEnabled)
        {
            SetFeatureFlagData(featureName, isEnabled, String.Empty);
        }

        private void SetFeatureFlagData(string featureName, bool isEnabled, string username)
        {
            var temp = new Feature();

            temp.IsEnabled = isEnabled;
            temp.FeatureName = featureName;
            temp.Username = username;

            FeatureRepositoryInstance.GetByUsernameReturnValue.Add(temp);
        }
    }
}
