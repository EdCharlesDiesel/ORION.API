using System.Security.Claims;
using System.Threading.Tasks;
using ORION.Admin.Security;
using Xunit;

namespace ORION.Admin.UnitTests.Security
{
    public class EditBusinessOwnerHandlerFixture
    {
        [Fact]
        public async Task HandlerSucceedsWhenUserIsAuthorizedToEdit_DirectPermissions()
        {
            var tester = new AuthorizationHandlerTester<
                EditBusinessOwnerRequirement, EditBusinessOwnerHandler>(
                    new EditBusinessOwnerRequirement(),
                    new EditBusinessOwnerHandler());

            tester.AddRouteDataValue("id", 123);
            tester.AddClaim(SecurityConstants.PermissionName_Edit, "123");

            await tester.AssertSuccess();
        }

        [Fact]
        public async Task HandlerSucceedsWhenUserIsAuthorizedToEdit_Administrator()
        {
            var tester = new AuthorizationHandlerTester<
                EditBusinessOwnerRequirement, EditBusinessOwnerHandler>(
                    new EditBusinessOwnerRequirement(),
                    new EditBusinessOwnerHandler());

            tester.AddRouteDataValue("id", 123);
            tester.AddClaim(ClaimTypes.Role, SecurityConstants.RoleName_Admin);

            await tester.AssertSuccess();
        }

        [Fact]
        public async Task HandlerFailsWhenUserIsNotAuthorizedToEdit()
        {
            var tester = new AuthorizationHandlerTester<
                EditBusinessOwnerRequirement, EditBusinessOwnerHandler>(
                    new EditBusinessOwnerRequirement(),
                    new EditBusinessOwnerHandler());

            tester.AddRouteDataValue("id", 123);
            tester.AddClaim(SecurityConstants.PermissionName_Edit, "123");

            await tester.AssertFailure();
        }


    }
}