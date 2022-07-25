using System.Security.Claims;

namespace ORION.Admin.Security
{
    public interface IUserClaimsPrincipalProvider
    {
        ClaimsPrincipal GetUser();
    }
}