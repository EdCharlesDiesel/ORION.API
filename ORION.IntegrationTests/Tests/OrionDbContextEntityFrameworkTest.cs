using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Contexts;
using ORION.DataAccess.Models;
using Xunit;
//FIXME Fix this test
namespace ORION.IntegrationTests.Tests
{
    public class OrionDbContextEntityFrameworkTest
    {
        public OrionDbContextEntityFrameworkTest()
        {
             _SystemUnderTest = null;
        }

        private OrionDbContext _SystemUnderTest;
        public OrionDbContext SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new OrionDesignTimeDbContextFactory().Create();

                    _SystemUnderTest.Database.EnsureCreated();
                }

                return _SystemUnderTest;
            }
        }

       [Fact]
       // [TestCategory("Integration.Sql")]
        public void EntityFramework_SavePerson_Simple()
        {
            var person = new Person();

            person.FirstName = "test_fn";
            person.LastName = "test_ln";

            SystemUnderTest.Persons.Add(person);

            SystemUnderTest.SaveChanges();

           Assert.NotEqual<int>(0, person.Id);
        }

        
        [Fact]
        //[TestCategory("Integration.Sql")]
        public void EntityFramework_SavePersonWithBusiness_SingleBusiness()
        {
            var person = new Person();

            person.FirstName = "from_fn_1";
            person.LastName = "from_ln_1";

            var expectedBusinessType = "Role";
            var expectedBusinessValue = "US Senator";

            person.AddBusiness(expectedBusinessType, expectedBusinessValue);

            SystemUnderTest.Persons.Add(person);

            SystemUnderTest.SaveChanges();

           Assert.NotEqual<int>(0, person.Id);
           Assert.NotEqual<int>(0, person.Businesses[0].Id);
        }

        [Fact]
        //[TestCategory("Integration.Sql")]
        public void EntityFramework_SavePersonWithBusiness_MultipleBusineses()
        {
            var person = new Person();

            person.FirstName = "from_fn_1";
            person.LastName = "from_ln_1";

            person.AddBusiness("Role", "US Senator");
            person.AddBusiness("Birth Date", new DateTime(1928, 3, 21));

            SystemUnderTest.Persons.Add(person);

            SystemUnderTest.SaveChanges();

            Assert.NotEqual<int>(0, person.Id);
            Assert.NotEqual<int>(0, person.Businesses[0].Id);
            Assert.NotEqual<int>(0, person.Businesses[1].Id);
        }

        [Fact(Skip = "GetAllBusinessOwners_DefaultMediaTypeReturnedIsJson")]
        //[TestCategory("Integration.Sql")]
        public void EntityFramework_LoadPersonWithBusineses_UsingFreshDbContext_FieldsArePopulated()
        {
            var expected = new Person();

            expected.FirstName = "from_fn_1";
            expected.LastName = "from_ln_1";

            expected.AddBusiness("Role", "US Senator");
            expected.AddBusiness("Birth Date", new DateTime(1928, 3, 21));

            SystemUnderTest.Persons.Add(expected);

            SystemUnderTest.SaveChanges();

            _SystemUnderTest = null;

            var actual = (
                from temp in SystemUnderTest.Persons.Include(x => x.Businesses)
                where temp.Id == expected.Id
                select temp
                ).FirstOrDefault();

            Assert.NotNull(actual);
            Assert.NotNull(actual.Businesses);
            Assert.Equal<int>(2, actual.Businesses.Count);

            foreach (var actualBusiness in actual.Businesses)
            {
                Assert.NotNull(actualBusiness.Person);
            }
        }
    }
}
