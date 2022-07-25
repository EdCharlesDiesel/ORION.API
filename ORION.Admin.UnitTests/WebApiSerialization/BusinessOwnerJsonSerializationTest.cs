using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.WebApiSerialization
{
    public class BusinessOwnerJsonSerializationTest
    {
        public BusinessOwnerJsonSerializationTest()
        {
            _SystemUnderTest = null;
        }

        private JsonSerializer _SystemUnderTest;
        public JsonSerializer SystemUnderTest
        {
            get
            {
                Assert.NotNull(_SystemUnderTest);

                return _SystemUnderTest;
            }
        }

        private void InitializeForPascalCase()
        {
            _SystemUnderTest = new JsonSerializer();
        }

        private void InitializeForCamelCase()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            };

            _SystemUnderTest = new JsonSerializer();
            _SystemUnderTest.ContractResolver = contractResolver;
        }

        [Fact]
        public void TermIsDeletedIsNotSerializedIntoJson_CamelCase()
        {
            // arrange
            InitializeForCamelCase();

            var serializeThis =
                UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner();

            // act
            var json = SerializeToJsonString(serializeThis);

            // assert
            var businessOwnerAsJson = JObject.Parse(json);

            var terms = businessOwnerAsJson["terms"] as JArray;

            Assert.NotNull(terms);
            Assert.Equal<int>(2, terms.Count);

            var term = terms[0];

            var isDeleted = term["isDeleted"];

            Assert.Null(isDeleted);
        }

        [Fact]
        public void TermIsDeletedIsNotSerializedIntoJson_PascalCase()
        {
            // arrange
            InitializeForPascalCase();

            var serializeThis =
               UnitTestUtility.GetKhotsoMokhethiAsBusinessOwner();

            // act
            var json = SerializeToJsonString(serializeThis);

            // assert
            var businessOwnerAsJson = JObject.Parse(json);

            var terms = businessOwnerAsJson["Terms"] as JArray;

            Assert.NotNull(terms);
            Assert.Equal<int>(2, terms.Count);

            var term = terms[0];

            var isDeleted = term["IsDeleted"];

            Assert.Null(isDeleted);
        }

        private string SerializeToJsonString(BusinessOwner serializeThis)
        {
            var builder = new StringBuilder();

            SystemUnderTest.Serialize(
                new StringWriter(builder),
                serializeThis
            );

            return builder.ToString();
        }
    }
}