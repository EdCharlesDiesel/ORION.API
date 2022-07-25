using Microsoft.AspNetCore.Authorization;
using Xunit;
using System;
using System.Linq;

namespace ORION.Admin.UnitTests.Security
{
    public static class SecurityAttributeUtility
    {
        public static void AssertAuthorizeAttributeRolesOnMethod(
            string expectedRoles,
            Type containingDataType, string methodName,
            params Type[] methodParameters
            )
        {
            var attribute =
                GetAttributeFromMethod<AuthorizeAttribute>(
                    containingDataType, methodName, methodParameters);

            Assert.NotNull(attribute);

            Assert.Equal(expectedRoles, attribute.Roles);
        }

        public static void AssertAuthorizeAttributePolicyOnMethod(
            string expectedPolicy,
            Type containingDataType, string methodName,
            params Type[] methodParameters
            )
        {
            var attribute =
                GetAttributeFromMethod<AuthorizeAttribute>(
                    containingDataType, methodName, methodParameters);

            Assert.NotNull(attribute);

            Assert.Equal(expectedPolicy, attribute.Policy);
        }

        public static void AssertAllowAnonymousAttributeOnMethod(
            Type containingDataType,
            string methodName,
            params Type[] methodParameters
    )
        {
            var attribute =
                GetAttributeFromMethod<AllowAnonymousAttribute>(
                    containingDataType, methodName, methodParameters);

            Assert.NotNull(attribute);
        }

        public static void AssertAuthorizeAttributeRolesOnClass(
            string expectedRoles,
            Type containingDataType
            )
        {
            var attribute =
                GetAttributeFromClass<AuthorizeAttribute>(
                    containingDataType);

            Assert.NotNull(attribute);

            Assert.Equal<string>(expectedRoles, attribute.Roles);
        }

        private static T GetAttributeFromMethod<T>(
            Type containingDataType,
            string methodName,
            params Type[] methodArgs) where T : Attribute
        {
            var method = containingDataType.GetMethod(
                methodName, methodArgs);

            Assert.NotNull(method);

            var attribute = method.GetCustomAttributes(
                typeof(T), true).FirstOrDefault();

            return attribute as T;
        }

        private static T? GetAttributeFromClass<T>(
            Type containingDataType)
            where T : Attribute
        {

            var attribute = containingDataType.GetCustomAttributes(
                typeof(T), true).FirstOrDefault();

            return attribute as T;
        }
    }
}
