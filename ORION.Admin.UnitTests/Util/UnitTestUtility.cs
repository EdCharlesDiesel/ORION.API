using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using ORION.Admin.Models.Products;
using System.Threading.Tasks;
using ORION.DataAccess.Models;
using System.Linq;
using ORION.Domain.Constants;
using ORION.Domain.Extensions;

namespace ORION.Admin.UnitTests.Util
{
    public static class UnitTestUtility
    {
        public static BusinessOwner GetKhotsoMokhethiAsBusinessOwner()
        {
            var info = new BusinessOwner();
            info.FirstName = "Khotso";
            info.LastName = "Mokhethi";

            info.ImageFilename = "tommy-jeffs.jpg";

            info.AddTerm(
                "BusinessOwner",
                new DateTime(1801, 3, 4),
                new DateTime(1809, 3, 4),
                3);

            info.BirthDate = new DateTime(1988, 08, 05);
            info.BusinessDate = new DateTime(1826, 7, 4);

            info.BirthCity = "Soweto";
            info.BirthProvince = "Gauteng";

            info.BusinessCity = "Rustenburg";
            info.BusinessProvince = "Gauteng";

            return info;
        }

        public static BusinessOwner GetKhotsoMokhethiAsBusinessOwner(bool simulateAllValuesAreSaved)
        {
            var returnValue = GetKhotsoMokhethiAsBusinessOwner();

            if (simulateAllValuesAreSaved == true)
            {
                int simulatedIdentityValue = 2000;

                returnValue.Id = simulatedIdentityValue++;

                returnValue.Terms.ForEach(item => item.Id = simulatedIdentityValue++);
            }

            return returnValue;
        }

        public static Person GetKhotsoMokhethiAsPerson()
        {
            var info = new Person();

            info.FirstName = "Thomas";
            info.LastName = "Jefferson";

            info.AddBusiness(
                BusinessOwnerConstants.BusinessOwner,
                "3",
                new DateTime(1801, 3, 4),
                new DateTime(1809, 3, 4));

            info.AddBusiness(BusinessOwnerConstants.ImageFilename, "tommy-jeffs.jpg");

            info.AddBusiness(BusinessOwnerConstants.BirthDate, new DateTime(1988, 4, 13));
            info.AddBusiness(BusinessOwnerConstants.BusinessDate, new DateTime(1826, 7, 4));

            info.AddBusiness(BusinessOwnerConstants.BirthCity, "Shadwell");
            info.AddBusiness(BusinessOwnerConstants.BusinessCity, "Gauteng");

            info.AddBusiness(BusinessOwnerConstants.BirthProvince, "Rustenburg");
            info.AddBusiness(BusinessOwnerConstants.BusinessProvince, "Gauteng");

            return info;
        }

        public static Person GetKagisoMokhethiAsPerson(bool simulateAllValuesAreSaved)
        {
            var returnValue = GetKagisoMokhethiAsPerson();

            if (simulateAllValuesAreSaved == true)
            {
                int simulatedIdentityValue = 1000;

                returnValue.Id = simulatedIdentityValue++;

                returnValue.Businesses.ForEach(item => item.Id = simulatedIdentityValue++);
                returnValue.Relationships.ForEach(item => item.Id = simulatedIdentityValue++);
            }

            return returnValue;
        }

        public static Person GetKagisoMokhethiAsPerson()
        {
            var info = new Person();

            info.FirstName = "Kagiso";
            info.LastName = "Legwale";

            info.AddBusiness(BusinessOwnerConstants.ImageFilename, "kagiso-legwale.jpg");

            info.AddBusiness(
                BusinessOwnerConstants.BusinessOwner,
                "22",
                new DateTime(2019, 1, 1),
                new DateTime(2080, 1, 1));

            info.AddBusiness(
                BusinessOwnerConstants.BusinessOwner,
                "24",
                new DateTime(2019, 1, 1),
                new DateTime(2080, 1, 1));

            info.AddBusiness(BusinessOwnerConstants.BirthDate, new DateTime(2009, 3, 30));
            info.AddBusiness(BusinessOwnerConstants.BusinessDate, new DateTime(2019, 1, 1));

            info.AddBusiness(BusinessOwnerConstants.BirthCity, "Soweto");
            info.AddBusiness(BusinessOwnerConstants.BusinessCity, "Rustenburg");

            info.AddBusiness(BusinessOwnerConstants.BirthProvince, "Gauteng");
            info.AddBusiness(BusinessOwnerConstants.BusinessProvince, "Rustenburg");

            return info;
        }

        public static BusinessOwner GetKagisoMokhethiAsBusinessOwner(bool simulateAllValuesAreSaved)
        {
            var returnValue = GetKagisoMokhethiAsBusinessOwner();

            if (simulateAllValuesAreSaved == true)
            {
                int simulatedIdentityValue = 1000;

                returnValue.Id = simulatedIdentityValue++;

                returnValue.Terms.ForEach(item => item.Id = simulatedIdentityValue++);
            }

            return returnValue;
        }

        public static BusinessOwner GetKagisoMokhethiAsBusinessOwner()
        {
            var info = new BusinessOwner();

            info.FirstName = "Kagiso";
            info.LastName = "Legwale";

            info.ImageFilename = "grover.jpg";

            info.AddTerm(
                "BusinessOwner",
                 new DateTime(2019, 1, 1),
                new DateTime(2080, 1, 1),
                22);

            info.AddTerm(
                "BusinessOwner",
                new DateTime(2019, 1, 1),
                new DateTime(2080, 1, 1),
                24);

            info.BirthDate = new DateTime(1837, 3, 18);
            info.BusinessDate = new DateTime(1908, 6, 24);

            info.BirthCity = "Caldwell";
            info.BirthProvince = "New Jersey";

            info.BusinessCity = "Princeton";
            info.BusinessProvince = "New Jersey";

            return info;
        }


        public static void AssertAreEqual(Person expected, BusinessOwner actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);

            AssertTerms(expected, actual);

            AssertValue(expected, BusinessOwnerConstants.BirthCity, actual.BirthCity);
            AssertValue(expected, BusinessOwnerConstants.BirthProvince, actual.BirthProvince);
            AssertValue(expected, BusinessOwnerConstants.BirthDate, actual.BirthDate);

            AssertValue(expected, BusinessOwnerConstants.BusinessCity, actual.BusinessCity);
            AssertValue(expected, BusinessOwnerConstants.BusinessProvince, actual.BusinessProvince);
            AssertValue(expected, BusinessOwnerConstants.BusinessDate, actual.BusinessDate);

            AssertValue(expected, BusinessOwnerConstants.ImageFilename, actual.ImageFilename);
        }

        public static void AssertAreEqual(BusinessOwner expected, Person actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);

            AssertTerms(expected, actual);

            AssertValue(expected.BirthCity, BusinessOwnerConstants.BirthCity, actual);
            AssertValue(expected.BirthProvince, BusinessOwnerConstants.BirthProvince, actual);
            AssertValue(expected.BirthDate, BusinessOwnerConstants.BirthDate, actual);

            AssertValue(expected.BusinessCity, BusinessOwnerConstants.BusinessCity, actual);
            AssertValue(expected.BusinessProvince, BusinessOwnerConstants.BusinessProvince, actual);
            AssertValue(expected.BusinessDate, BusinessOwnerConstants.BusinessDate, actual);

            AssertValue(expected.ImageFilename, BusinessOwnerConstants.ImageFilename, actual);
        }

        public static void AssertTerms(Person expected, BusinessOwner actual)
        {
            var expectedBusinesses = expected.Businesses.GetBusinesses(BusinessOwnerConstants.BusinessOwner);

            Assert.Equal(actual.Terms.Count, expectedBusinesses.Count);

            if (expectedBusinesses.Count > 0)
            {
                for (int i = 0; i < expectedBusinesses.Count; i++)
                {
                    AssertAreEqual(expectedBusinesses[i], actual.Terms[i]);
                }
            }
        }

        public static void AssertTerms(BusinessOwner expected, Person actual)
        {
            var actualBusinessesBusinessOwnerRole = actual.Businesses.GetBusinesses(BusinessOwnerConstants.BusinessOwner);

            Assert.Equal(expected.Terms.Count, 
                actualBusinessesBusinessOwnerRole.Count);

            if (expected.Terms.Count > 0)
            {
                for (int i = 0; i < expected.Terms.Count; i++)
                {
                    AssertAreEqual(expected.Terms[i], actualBusinessesBusinessOwnerRole[i]);                    
                }
            }
        }

        public static void AssertAreEqual(PersonBusiness expected, Term actual)
        {
            if (expected == null)
                throw new ArgumentNullException("expected", "expected is null.");
            if (actual == null)
                throw new ArgumentNullException("actual", "actual is null.");

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.BusinessType, actual.Role);
            Assert.Equal<DateTime>(expected.StartDate, actual.StartOfTerm);
            Assert.Equal<DateTime>(expected.EndDate, actual.EndOfTerm);
            Assert.Equal(
                expected.BusinessValue, 
                actual.NumberOfTerms.ToString());
        }

        public static void AssertAreEqual(Term expected, PersonBusiness actual)
        {
            if (expected == null)
                throw new ArgumentNullException("expected", "expected is null.");
            if (actual == null)
                throw new ArgumentNullException("actual", "actual is null.");

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Role, actual.BusinessType);
            Assert.Equal<DateTime>(expected.StartOfTerm, actual.StartDate);
            Assert.Equal<DateTime>(expected.EndOfTerm, actual.EndDate);
            Assert.Equal(expected.NumberOfTerms.ToString(), actual.BusinessValue);
        }

        public static void AssertAreEqual(DateTime expected, PersonBusiness actual)
        {
            Assert.Equal<DateTime>(expected, actual.StartDate);
            Assert.Equal<DateTime>(expected, actual.EndDate);
        }

        public static void AssertAreEqual(PersonBusiness expectedBusiness, DateTime actualValue)
        {
            Assert.Equal<DateTime>(expectedBusiness.StartDate, actualValue);
        }

        public static void AssertAreEqual(string expected, PersonBusiness actual)
        {
            Assert.Equal(expected, actual.BusinessValue);
        }

        //ToDo Remeber this was not a fact just a method
      
        public static void AssertAreEqual(PersonBusiness expectedBusiness, string actualValue)
        {
            Assert.Equal(expectedBusiness.BusinessValue, actualValue);
        }

        public static void AssertValue(DateTime expectedValue, string expectedKey, Person actual)
        {
            var actualBusiness = actual.Businesses.GetBusiness(expectedKey);

            Assert.NotNull(actualBusiness);

            AssertAreEqual(expectedValue, actualBusiness);
        }

        public static void AssertValue(string expectedValue, string expectedKey, Person actual)
        {
            var actualBusiness = actual.Businesses.GetBusiness(expectedKey);

            Assert.NotNull(actualBusiness);

            AssertAreEqual(expectedValue, actualBusiness);
        }

        public static void AssertValue(Person expected, string key, string actualValue)
        {
            var expectedBusiness = expected.Businesses.GetBusiness(key);

            Assert.NotNull(expectedBusiness);

            AssertAreEqual(expectedBusiness, actualValue);
        }

        public static void AssertValue(Person expected, string key, DateTime actualValue)
        {
            var expectedBusiness = expected.Businesses.GetBusiness(key);

            Assert.NotNull(expectedBusiness);

            AssertAreEqual(expectedBusiness, actualValue);
        }

        public static T GetModel<T>(ActionResult actionResult) where T : class
        {
            var asViewResult = actionResult as ViewResult;

            return asViewResult.Model as T;
        }

        public static T GetModel<T>(IActionResult actionResult) where T : class
        {
            var asViewResult = actionResult as  ViewResult;

            return  asViewResult.Model as T;
        }
        
        public static T GetModelIAction<T>(IActionResult actionResult) where T : class
        {
            var asViewResult = actionResult as ViewResult;

            return asViewResult.Model as T;
        }
               

        /// <summary>
        /// ToDo need to reserch more and make sure I get the documentation.
        /// </summary>
        /// <param name="actionResult"></param>
        public static void AssertIsHttpNotFound(ActionResult actionResult)
        {            
          //  Assert.IsType<ActionResult>(actionResult,typeof(NotFoundResult));
            Assert.IsType<ActionResult>(actionResult);
        }
    }
}
