using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using ORION.DataAccess.Services;
using ORION.DataAccess.Strategy;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using ORION.Domain.Constants;

namespace ORION.Admin.UnitTests.Services
{
    public class BusinessOwnerServiceTest
    {
       // public BusinessOwnerServiceTest()
       // {
       //     _SystemUnderTest = null;
       //     _PersonRepositoryInstance = null;
       //     _ValidatorStrategyInstance = null; 
       // }
       
       // private BusinessOwnerService _SystemUnderTest;

       // private BusinessOwnerService SystemUnderTest
       // {
       //     get
       //     {
       //         if (_SystemUnderTest == null)
       //         {
       //             _SystemUnderTest = 
       //                 new BusinessOwnerService(
       //                     PersonRepositoryInstance,
       //                     ValidatorStrategyInstance, 
       //                     new DefaultDaysInOfficeStrategy());
       //         }

       //         return _SystemUnderTest;
       //     }
       // }

       // private MockBusinessOwnerValidatorStrategy _ValidatorStrategyInstance;
       // public MockBusinessOwnerValidatorStrategy ValidatorStrategyInstance
       // {
       //     get
       //     {
       //         if (_ValidatorStrategyInstance == null)
       //         {
       //             _ValidatorStrategyInstance = new MockBusinessOwnerValidatorStrategy();
       //         }

       //         return _ValidatorStrategyInstance;
       //     }
       // }
        

       // private InMemoryRepository<Person> _PersonRepositoryInstance;
       // public InMemoryRepository<Person> PersonRepositoryInstance
       // {
       //     get
       //     {
       //         if (_PersonRepositoryInstance == null)
       //         {
       //             _PersonRepositoryInstance = new InMemoryRepository<Person>();
       //         }

       //         return _PersonRepositoryInstance;
       //     }
       // }


       // private void PopulateRepositoryWithTestData()
       // {
       //     PersonRepositoryInstance.Save(UnitTestUtility.GetKagisoMokhethiAsPerson(true));
       //     PersonRepositoryInstance.Save(UnitTestUtility.GetKagisoMokhethiAsPerson());

       //     var personWithNoBusinesss = new Person()
       //     {
       //         FirstName = "Skippy",
       //         LastName = "DefinitelyNotBusinessOwner"
       //     };
       //     PersonRepositoryInstance.Save(personWithNoBusinesss);

       //     var personWhoWasVP = new Person()
       //     {
       //         FirstName = "Al",
       //         LastName = "Gore"
       //     };

       //     personWhoWasVP.AddBusiness(BusinessOwnerConstants.ViceBusinessOwner, 
       //         new DateTime(1992, 1, 1), 
       //         new DateTime(2000, 1, 1));

       //     PersonRepositoryInstance.Save(personWhoWasVP);
       // }

       // [Fact]
       //// [ExpectedException(typeof(InvalidOperationException))]
       // public void GivenAnInvalidBusinessOwnerWhenSaveIsCalledThenThrowAnException()
       // {
       //     ValidatorStrategyInstance.IsValidReturnValue = false;

       //     SystemUnderTest.Save(new BusinessOwner());
       // }

       // [Fact]
       // public void GetAllBusinessOwnersOnlyReturnsBusinessOwners()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.GetBusinessOwners();

       //     Assert.Equal<int>(2, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       //     Assert.True(lastNames.Contains("Jefferson"));
       // }

       // [Fact]
       // public void SearchByFirstName()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("Grover", String.Empty);

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByFirstNamePartial()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("ove", String.Empty);

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByLastName()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search(String.Empty, "Cleveland");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByLastNamePartial()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search(String.Empty, "eve");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByFirstNameLastName()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("Grover", "Cleveland");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByFirstNameLastNamePartial()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("ove", "eve");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByFirstNameLastNameCaseInsensitive()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("grover", "cleveland");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByPartialFirstNameLastName()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("Gro", "Cle");

       //     Assert.Equal<int>(1, actual.Count);

       //     var lastNames =
       //         (from temp in actual
       //          select temp.LastName).ToList();

       //     Assert.True(lastNames.Contains("Cleveland"));
       // }

       // [Fact]
       // public void SearchByEmptyFirstNameLastNameReturnsAll()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search(
       //         String.Empty, String.Empty);

       //     Assert.Equal<int>(2, actual.Count);            
       // }

       // [Fact]
       // public void SearchByNullFirstNameLastNameReturnsAll()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search(
       //         null, null);

       //     Assert.Equal<int>(2, actual.Count);
       // }

       // [Fact]
       // public void SearchByBogusFirstNameLastNameReturnsNoResults()
       // {
       //     PopulateRepositoryWithTestData();

       //     IList<BusinessOwner> actual = SystemUnderTest.Search("Thomas", "Cleveland");

       //     Assert.Equal<int>(0, actual.Count);
       // }

       // [Fact]
       // public void WhenSaveIsCalledThenIdIsNotZeroAndIsInRepository()
       // {
       //     BusinessOwner saveThis = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

       //     SystemUnderTest.Save(saveThis);

       //     Assert.NotEqual<int>(0, saveThis.Id);

       //     var actual = PersonRepositoryInstance.GetById(saveThis.Id);

       //     Assert.NotNull(actual);
       // }

       // [Fact]
       // public void WhenSaveIsCalledUsingAnExistingBusinessOwnerModificationsAreSavedInRepository()
       // {
       //     PopulateRepositoryWithTestData();

       //     Person existingPerson = GetBusinessOwnerByNameFromTestRepository("Cleveland");

       //     BusinessOwner existingBusinessOwner = SystemUnderTest.GetBusinessOwnerById(existingPerson.Id);

       //     ModifyValues(existingBusinessOwner);

       //     SystemUnderTest.Save(existingBusinessOwner);
       //     //ToDo Investigate
       //    //UnitTestUtility.AssertEqual(existingBusinessOwner, existingPerson);
       // }

       // [Fact]
       // public void WhenSaveIsCalledUsingAnExistingBusinessOwnerThenDeletedTermsAreRemovedFromCollection()
       // {
       //     PopulateRepositoryWithTestData();

       //     Person existingPerson = GetBusinessOwnerByNameFromTestRepository("Cleveland");

       //     BusinessOwner existingBusinessOwner = SystemUnderTest.GetBusinessOwnerById(existingPerson.Id);

       //     var existingTerm0 = existingBusinessOwner.Terms[0];

       //     existingTerm0.IsDeleted = true;

       //     SystemUnderTest.Save(existingBusinessOwner);

       //     Assert.Equal<int>(1, existingBusinessOwner.Terms.Count);
       //     Assert.False(existingBusinessOwner.Terms.Contains(existingTerm0));
       // }
        
       // [Fact]
       // //[ExpectedException(typeof(InvalidOperationException))]
       // public void WhenSaveIsCalledUsingABusinessOwnerWithAnInvalidIdThenAnExceptionIsThrown()
       // {
       //     BusinessOwner businessOwnerWithFakeId = UnitTestUtility.GetKagisoMokhethiAsBusinessOwner();

       //     businessOwnerWithFakeId.Id = 12341234;

       //     SystemUnderTest.Save(businessOwnerWithFakeId);
       // }

       // private void ModifyValues(BusinessOwner existingBusinessOwner)
       // {
       //     existingBusinessOwner.BirthCity = "Lollipop";
       //     existingBusinessOwner.BirthProvince = "Missouri";

       //     existingBusinessOwner.BirthDate = new DateTime(1954, 6, 22);
       //     existingBusinessOwner.BusinessDate = new DateTime(1982, 11, 14);

       //     existingBusinessOwner.BusinessCity = "Gurgle";
       //     existingBusinessOwner.BusinessProvince = "Montana";

       //     existingBusinessOwner.FirstName = "Grovegrove";
       //     existingBusinessOwner.LastName = "Washington, Jr.";

       //     existingBusinessOwner.Terms[0].StartOfTerm = new DateTime(1977, 8, 29);
       //     existingBusinessOwner.Terms[0].EndOfTerm = new DateTime(1981, 5, 3);
       // }

       // [Fact]
       // public void GetBusinessOwnerById()
       // {
       //     PopulateRepositoryWithTestData();

       //     Person expected = GetBusinessOwnerByNameFromTestRepository("Jefferson");

       //     BusinessOwner actual = SystemUnderTest.GetBusinessOwnerById(expected.Id);

       //     Assert.NotNull(actual);

       //     Assert.Equal<int>(expected.Id, actual.Id);
       //     Assert.Equal(expected.LastName, actual.LastName);
       // }

       // [Fact]
       // public void DeleteBusinessOwnerByIdRemovesBusinessOwnerFromRepository()
       // {
       //     PopulateRepositoryWithTestData();

       //     Person expected = GetBusinessOwnerByNameFromTestRepository("Jefferson");

       //     SystemUnderTest.DeleteBusinessOwnerById(expected.Id);

       //     Assert.Null(PersonRepositoryInstance.GetById(expected.Id));
       // }

       // private Person GetBusinessOwnerByNameFromTestRepository(string lastName)
       // {
       //     var match = (from temp in PersonRepositoryInstance.Items
       //                  where temp.LastName == lastName
       //                  select temp
       //                  ).FirstOrDefault();

       //     return match;
       // }      
    }    
}
