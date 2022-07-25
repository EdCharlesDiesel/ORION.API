using System;
using System.Linq;

namespace ORION.Admin
{
    public static class SecurityConstants
    {
        public const string RoleName_Admin = "BusinessOwners.Admin";
        public const string RoleName_User = "BusinessOwners.User";

        public const string PermissionName_View = "BusinessOwner.View";
        public const string PermissionName_Edit = "BusinessOwner.Edit";

        public const string Username_Admin = "admin@test.org";
        public const string Username_User1 = "user1@test.org";
        public const string Username_User2 = "user2@test.org";
        public const string Username_Subscriber1 = "subscriber1@test.org";
        public const string Username_Subscriber2 = "subscriber2@test.org";
        
        public const string DefaultPassword = "password";

        public const string PolicyName_EditBusinessOwner = "EditBusinessOwnerPolicy";

        public const string SubscriptionType_Basic = "Basic";
        public const string SubscriptionType_Ultimate = "Ultimate";

        public const string Claim_SubscriptionType = "SubscriptionType";
    }
}
