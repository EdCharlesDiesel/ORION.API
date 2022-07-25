namespace ORION.Admin.Security
{
    public interface IUserAuthorizationStrategy
    {
        bool IsAuthorizedForSearch { get; }
        bool IsAuthorizedForImages { get; }
    }
}